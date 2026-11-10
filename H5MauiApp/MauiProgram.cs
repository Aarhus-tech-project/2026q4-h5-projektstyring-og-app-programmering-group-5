using CommunityToolkit.Maui;
using H5MauiApp.Auth;
using H5MauiApp.Pages.LoginPage;
using H5MauiApp.Pages.MyTripsPage;
using H5MauiApp.Pages.Popups.CreateTrip;
using H5MauiApp.Pages.SignupPage;
using H5MauiApp.Pages.TripDetails;
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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}