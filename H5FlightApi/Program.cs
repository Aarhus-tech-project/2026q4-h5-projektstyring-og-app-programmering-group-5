using System.Text.Json.Serialization;
using FluentValidation;
using H5FlightApi.HttpClients.Geoapify;
using H5FlightApi.HttpClients.Geoapify.GeoapifyHttpClient;
using H5FlightApi.Persistence;
using H5FlightApi.Services;
using H5FlightApi.Services.AppConfigService;
using H5FlightApi.Services.CurrentUserService;
using JasperFx.CodeGeneration.Model;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Serilog;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            Description = "Paste the accessToken returned by /Login.",
        }
    );

    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = [],
        }
    );
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles;
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles;
});

// todo extract to config 
builder.Services.AddSerilog(config => config
    .MinimumLevel.Error()
    .WriteTo.File("logs/errors-.log", rollingInterval: RollingInterval.Day));

builder.Services.AddProblemDetails();

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IAppConfigService, AppConfigService>();

// Use add http client instead of serivce? research 
builder.Services.AddTransient<IGeoapifyHttpClient, GeoapifyHttpClient>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.UseWolverine(opts =>
{
    opts.Durability.Mode = DurabilityMode.MediatorOnly;
    opts.UseRuntimeCompilation(); // todo research 

    // opts.CodeGeneration.AlwaysUseServiceLocationFor<GeoapifyHttpClient>();
    // opts.CodeGeneration.AlwaysUseServiceLocationFor<AppDbContext>();

    opts.ServiceLocationPolicy = ServiceLocationPolicy.AlwaysAllowed;
});

// todo required? 
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services
    .AddAuthentication(BearerTokenDefaults.AuthenticationScheme)
    .AddBearerToken(options => { options.BearerTokenExpiration = TimeSpan.FromDays(7); });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

// app.UseMiddleware<CurrentUserMiddleware>();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
}

app.UseHttpsRedirection();

app.Services.GetRequiredService<AppConfigService>().Validate();

app.Run();