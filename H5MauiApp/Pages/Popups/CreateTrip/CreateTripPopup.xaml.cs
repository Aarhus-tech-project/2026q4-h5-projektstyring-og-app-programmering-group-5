using System.Net.Http.Json;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace H5MauiApp.Pages.Popups.CreateTrip;

public partial class CreateTripPopup : ContentView
{
    public CreateTripPopup(CreateTripPopupViewModel createTripPopupViewModel)
    {
        InitializeComponent();
        BindingContext = createTripPopupViewModel;
    }
}

// todo håndter valideing i hele appen samterrors og popups, 