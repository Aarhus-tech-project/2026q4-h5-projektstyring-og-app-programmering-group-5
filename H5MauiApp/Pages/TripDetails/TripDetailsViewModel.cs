using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using H5MauiApp.ApiModels;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Services.AlertService;

namespace H5MauiApp.Pages.TripDetails;

[QueryProperty(nameof(TripId), "tripId")]
public partial class TripDetailsViewModel(IErrorHandler errorHandler, HttpClient httpClient, IAlertService alertService) : ObservableObject
{
    [ObservableProperty] private Guid tripId;
    [ObservableProperty] private Trip trip;

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