using System.Collections.ObjectModel;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.ApiModels;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Services.AlertService;

namespace H5MauiApp.Pages.SelectSightSeeingPage;

[QueryProperty(nameof(TripId), "TripId")]
public partial class SelectSightSeeingViewModel(IErrorHandler errorHandler, HttpClient httpClient, IAlertService alertService) : ObservableObject
{
    [ObservableProperty] private string inputCountry;
    [ObservableProperty] private string inputCity;
    public ObservableCollection<Place> Places { get; set; } = new();

    [ObservableProperty] private Place selectedPlace;

    [ObservableProperty] private Guid tripId;

    [RelayCommand]
    public async Task GetPointsOfInterrestForCityAsync() => await errorHandler.Guard(async () =>
    {
        var res = await httpClient.PostAsJsonAsync("/GetPlacesForCity", new
            GetPlacesForCityRequest(InputCity, InputCountry));

        if (res.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlertAsync(res);
            return;
        }

        var places = await res.Content.ReadFromJsonAsync<List<Place>>();

        if (places.Count == 0 || places is null)
        {
            await alertService.ShowAlertAsync(AlertTitle.Error, "Could not get places");
            return;
        }

        Places.Clear();

        foreach (var place in places)
        {
            Places.Add(place);
        }
    });

    // todo væer sikker på at hvis du navigere tilbage med tilbage knapper  til sider, at deres query peroperties bliver sat. 

    // todo disable knappen hbis der ikke er valgt en ting 
    [RelayCommand] // todo hvorfor ksal vi have relay command research. 
    public async Task SelectPlace() => await errorHandler.Guard(async () =>
    {
        if (SelectedPlace is null)
        {
            await alertService.ShowAlertAsync(AlertTitle.Error, "No place selected");
            return;
        }

        var request = new SSelectPlaceForTripRequest(
            SelectedPlace.PlaceId,
            SelectedPlace.AddressLine1,
            SelectedPlace.AddressLine2,
            SelectedPlace.City,
            SelectedPlace.Lat,
            SelectedPlace.Lon,
            SelectedPlace.Name,
            TripId);

        var res = await httpClient.PostAsJsonAsync("/SelectPlaceForTrip", request);

        if (res.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlertAsync(res);
            return;
        }

        await alertService.ShowAlertAsync(AlertTitle.Success, "Place selected");
    });
}

// todo move to shared lib 
public record GetPlacesForCityRequest(string City, string Country);

public record SSelectPlaceForTripRequest(
    string PlaceId,
    string? AddressLine1,
    string? AddressLine2,
    string City,
    double Lat,
    double Lon,
    string? Name,
    Guid TripId);