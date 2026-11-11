using System.Collections.ObjectModel;
using System.Net.Http.Json;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.ApiModels;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Pages.Popups.CreateTrip;
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
            case CreateTripDialogResults.Success:
                // await GetTripsAsync();
                break;

            case CreateTripDialogResults.Error:
                // todo Handle the error.
                break;
        }
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