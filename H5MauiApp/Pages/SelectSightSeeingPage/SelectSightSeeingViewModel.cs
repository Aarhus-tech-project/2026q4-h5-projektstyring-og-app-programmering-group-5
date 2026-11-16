using System.Collections.ObjectModel;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.ApiModels;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Services.AlertService;

namespace H5MauiApp.Pages.SelectSightSeeingPage;

public partial class SelectSightSeeingViewModel(IErrorHandler errorHandler, HttpClient httpClient, IAlertService alertService) : ObservableObject
{
    [ObservableProperty] private string inputCountry;
    [ObservableProperty] private string inputCity;
    public ObservableCollection<Place> Places { get; set; } = new();

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

    [RelayCommand]
    public async Task SelectPlace() => await errorHandler.Guard(async () => { });
}

// todo move to shared lib 
public record GetPlacesForCityRequest(string City, string Country);