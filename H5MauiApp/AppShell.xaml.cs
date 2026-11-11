using H5MauiApp.Pages.CreateFlightPage;
using H5MauiApp.Pages.LoginPage;
using H5MauiApp.Pages.MyTripsPage;
using H5MauiApp.Pages.TripDetails;

namespace H5MauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Routing.RegisterRoute(nameof(MyTripsView), typeof(MyTripsView));
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(TripDetailsView), typeof(TripDetailsView));
        Routing.RegisterRoute(nameof(CreateFlightView), typeof(CreateFlightView));
    }
}