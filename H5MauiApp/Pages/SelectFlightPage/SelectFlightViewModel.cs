using CommunityToolkit.Mvvm.ComponentModel;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Pages.CreateFlightPage;

namespace H5MauiApp.Pages.SelectFlightPage;

[QueryProperty(nameof(FlightOption), "FlightOption")]
public partial class SelectFlightViewModel(IErrorHandler errorHandler, HttpClient httpClient) : ObservableObject
{
    [ObservableProperty] private FlightOption flightOption;
    [ObservableProperty] private FlightOption returningFlightOption;


    public async Task GetReturningFlight() => await errorHandler.Guard(async () =>
    {
        // var res = await httpClient.gex
    });
}