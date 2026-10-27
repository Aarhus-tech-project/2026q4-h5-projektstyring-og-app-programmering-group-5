using H5FlightApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.UseWolverine(opts =>
{
    opts.Durability.Mode = DurabilityMode.MediatorOnly;
    opts.UseRuntimeCompilation(); // todo research 
});

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
 
app.Run();

// todo swagger     

// TODO: Endpoints rest     

// LOGIN  / password and username return token 
// SIGNIN / create user 

// get my trips 
// get trip details 
// add flight to trip 

// get sight seeing spots for trip  