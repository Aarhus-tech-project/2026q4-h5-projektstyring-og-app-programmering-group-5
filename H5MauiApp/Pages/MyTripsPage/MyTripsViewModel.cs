using System.Collections.ObjectModel;
using System.Net.Http.Json;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.ApiModels;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Pages.Popups.CreateTrip;
using H5MauiApp.Pages.TripDetails;
using CreateTripPopup = H5MauiApp.Pages.Popups.CreateTrip.CreateTripPopup;

namespace H5MauiApp.Pages.MyTripsPage;

public partial class MyTripsViewModel(HttpClient httpClient, CreateTripPopup createTripPopup, IErrorHandler errorHandler) : ObservableObject
{
    public ObservableCollection<Trip> Trips { get; } = new();

    [RelayCommand]
    public async Task ShowPopup() => await errorHandler.Guard(async () =>
    {
        var result = await Shell.Current.ShowPopupAsync<CreateTripDialogResults>(createTripPopup);

        if (result.WasDismissedByTappingOutsideOfPopup)
        {
            return;
        }

        // todo if it calles get trips async or on navigated too when i clsoe the dialog, thats anoying 
        // gaurd the on navigated too so its once pr lifecycle of object, allow manual overwride if you want more usage.
        switch (result.Result)
        {
            case CreateTripDialogResults.Success: break;
            case CreateTripDialogResults.Error: break;
            // todo Handle the error. GØR DET INDE I POPUPPEN 
        }
    });

    // todo not sure if this gaurd can dobble catch erros inthing iside of guard usage in the new view 
    [RelayCommand]
    public async Task GoToDetailedTrip(Trip trip) => errorHandler.Guard(async () =>
    {
        var parameters = new ShellNavigationQueryParameters
        {
            ["tripId"] = trip.Id
        };

        await Shell.Current.GoToAsync(nameof(TripDetailsView), parameters);
    });

    public async Task GetTripsAsync() => await errorHandler.Guard(async () =>
    {
        var trips = await httpClient.GetFromJsonAsync<List<Trip>>("/Trip");

        // todo make sure trips arrives saftely? 

        Trips.Clear();

        // todo annoying to use observable collection, keeps UI responsice and bring UI updates but it 2x itterates my array 
        foreach (var trip in trips ?? [])
        {
            Trips.Add(trip);
        }
    });
}