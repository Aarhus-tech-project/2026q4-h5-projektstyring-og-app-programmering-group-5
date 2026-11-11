using CommunityToolkit.Maui;
using H5MauiApp.Auth;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Pages.LoginPage;
using H5MauiApp.Pages.MyTripsPage;
using H5MauiApp.Pages.Popups.CreateTrip;
using H5MauiApp.Pages.SignupPage;
using Serilog;
using H5MauiApp.Pages.TripDetails;
using H5MauiApp.Services.AlertService;
using Microsoft.Extensions.Logging;

namespace H5MauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // todo is busy activitit y indicator 

        builder.Logging.AddDebug();

        builder.Services.AddSingleton<IErrorHandler, AlertErrorHandler>();

        builder.Services.AddSingleton<TokenStore>();
        builder.Services.AddTransient<AuthHandler>();

        builder.Services.AddHttpClient("Api", c => c.BaseAddress = new Uri("http://100.116.135.57:5132"))
            .AddHttpMessageHandler<AuthHandler>();

        // Lets you keep injecting a plain HttpClient
        builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

        // todo ryd op samt extention methods 

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginView>();

        builder.Services.AddTransient<SignupViewModel>();
        builder.Services.AddTransient<SignupView>();

        builder.Services.AddTransient<MyTripsViewModel>();
        builder.Services.AddTransient<MyTripsView>();

        builder.Services.AddTransient<TripDetailsViewModel>();
        builder.Services.AddTransient<TripDetailsView>();

        builder.Services.AddTransient<CreateTripPopupViewModel>();
        builder.Services.AddTransient<CreateTripPopup>();

        builder.Services.AddTransient<IAlertService, AlertService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

//
// var app = builder.Build();
// var log = app.Services.GetRequiredService<ILogger<App>>();
//
// AppDomain.CurrentDomain.UnhandledException += (_, e) =>
//     log.LogCritical(e.ExceptionObject as Exception, "Fatal");
//
// TaskScheduler.UnobservedTaskException += (_, e) =>
// {
//     log.LogError(e.Exception, "Unobserved task");
//     e.SetObserved();
// };