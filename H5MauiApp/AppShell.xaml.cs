using H5MauiApp.Pages.LoginPage;
using H5MauiApp.Pages.MyTripsPage;

namespace H5MauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Routing.RegisterRoute(nameof(MyTripsView), typeof(MyTripsView));
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
    }
}