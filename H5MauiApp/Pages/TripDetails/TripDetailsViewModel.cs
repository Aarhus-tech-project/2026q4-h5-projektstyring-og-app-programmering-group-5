using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.ApiModels;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Pages.CreateFlightPage;
using H5MauiApp.Services.AlertService;

namespace H5MauiApp.Pages.TripDetails;

[QueryProperty(nameof(TripId), "tripId")]
public partial class TripDetailsViewModel(IErrorHandler errorHandler, HttpClient httpClient, IAlertService alertService) : ObservableObject
{
    [ObservableProperty] private Guid tripId;
    [ObservableProperty] private Trip trip;

    // todo this ruins go back button ? 
    [RelayCommand]
    public async Task GoToCreateFlightPage() => await errorHandler.Guard(async () => { await Shell.Current.GoToAsync(nameof(CreateFlightView)); });

    public async Task GetTripDetailsAsync() => await errorHandler.Guard(async () =>
    {
        // todo why is this 2x catching 
        var result = await httpClient.GetAsync($"/{tripId}");

        if (result.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlert(result);
        }

        var trip = await result.Content.ReadFromJsonAsync<Trip>();

        if (trip is null)
        {
            await alertService.ShowAlert(AlertTitle.Error, "Could not find trip with given id");
            return;
        }

        Trip = trip;
    });
}