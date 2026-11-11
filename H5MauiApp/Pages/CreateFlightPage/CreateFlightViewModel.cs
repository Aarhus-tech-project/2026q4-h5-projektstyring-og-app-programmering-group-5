using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using H5MauiApp.ApiModels;
using H5MauiApp.Data;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Services.AlertService;

namespace H5MauiApp.Pages.CreateFlightPage;

public partial class CreateFlightViewModel(IErrorHandler errorHandler, HttpClient httpClient, IAlertService alertService) : ObservableObject
{
    // Todo husk at dobblet tjekke der bliver retrned på dialoger med alert errors 

    [ObservableProperty] private Country? departureCountry;
    [ObservableProperty] private Country? destinationCountry;
    [ObservableProperty] private DateTime departureDate = DateTime.Today;
    [ObservableProperty] private DateTime returnDate = DateTime.Today;

    public ObservableCollection<FlightOption> BestFlights { get; } = new();

    public IReadOnlyList<Country> Countries { get; } =
        CountryData.Countries
            .OrderBy(
                country => country.Name,
                StringComparer.OrdinalIgnoreCase
            )   
            .ToArray();

    // todo is budy and cancelation token stuff, handle smeone spamming the buttons 

    [RelayCommand]
    public async Task GetAirports() => await errorHandler.Guard(async () =>
    {
        // todo insane god method, consider using services for this, or http client wrappers, 
        var getAirportsResponse = await httpClient.GetAsync(
            $"/airports?departureCountry={DepartureCountry?.Code}&arrivalCountry={DestinationCountry?.Code}");

        if (getAirportsResponse.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlert(getAirportsResponse);
            return;
        }

        var airports = await getAirportsResponse.Content.ReadFromJsonAsync<GetAirportsResponse>();

        if (airports is null || airports.ArrivalAirports.Count == 0 || airports.DepartureAirports.Count == 0)
        {
            await alertService.ShowAlert(AlertTitle.Error, "Could not get airports");
            return;
        }

        var departureCodes = airports.DepartureAirports.Select(a => a.IataCode).ToList();
        var destinationCodes = airports.ArrivalAirports.Select(a => a.IataCode).ToList();


        // todo vi skal have is busy indicator på 
        var getFlightsRequest = new GetFlightsRequest(departureCodes, destinationCodes,
            null, DateOnly.FromDateTime(DepartureDate), DateOnly.FromDateTime(ReturnDate));

        // var getFlightsRequest = new GetFlightsRequest(
        //     new List<string>
        //     {
        //         "YVR", "YUL", "YEG", "YOW", "YWG",
        //         "YHZ", "YLW", "YQB", "YHM", "YQG"
        //     },
        //     new List<string>
        //     {
        //         "ATL", "BOS", "BNA", "AUS", "ABQ",
        //         "BDL", "BUF", "BOI", "BHM", "ALB"
        //     },
        //     null,
        //     new DateOnly(2026, 11, 13),
        //     new DateOnly(2026, 11, 16));

        // var getFlightsRequest = new GetFlightsRequest(
        //     new List<string> { "ATL", "DFW", "DEN", "ORD", "LAX" },
        //     new List<string> { "YYZ", "YVR", "YUL", "YYC", "YEG" },
        //     null,
        //     DateOnly.FromDateTime(DepartureDate),
        //     DateOnly.FromDateTime(ReturnDate));
        //
        // var getFlightsRequest = new GetFlightsRequest(
        //     new List<string>
        //     {
        //         "YMF", "YBW", "YTP", "ZNA", "YZZ"
        //     },
        //     new List<string>
        //     {
        //         "NUP", "PPV", "BYW", "ATT", "PDB"
        //     },
        //     null,
        //     new DateOnly(2026, 11, 13),
        //     new DateOnly(2026, 11, 18));
        //
        // var getFlightsRequest = new GetFlightsRequest(
        //     new List<string> { "ATL", "DFW", "DEN", "ORD", "LAX" },
        //     new List<string> { "YYZ", "YVR", "YUL", "YYC", "YEG" },
        //     null,
        //     new DateOnly(2026, 11, 13),
        //     new DateOnly(2026, 11, 18));

        //
        // // todo serpaip can throw erros if nothing is fond with request. 
        // what to do if returning flight cant be found on a given date, suggest oter flights? would also consue credits. 

        var getFlightsResponse = await httpClient.PostAsJsonAsync("/flights", getFlightsRequest);
        // var getFlightsResponse = await httpClient.GetAsync(
        //     $"/flights?{departureCodes}&{arrivalCodes}" +
        //     $"&outboundDate={DateOnly.FromDateTime(DepartureDate):yyyy-MM-dd}" +
        //     $"&returnDate={DateOnly.FromDateTime(ReturnDate):yyyy-MM-dd}");

        if (getFlightsResponse.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlert(getFlightsResponse);
            return;
        }

        var flights = await getFlightsResponse.Content
            .ReadFromJsonAsync<List<FlightOption>>() ?? new List<FlightOption>();

        if (flights is null || flights.Count == 0)
        {
            await alertService.ShowAlert(AlertTitle.Error, "Could not get flights");
            return;
        }

        BestFlights.Clear();

        foreach (var flight in flights)
        {
            BestFlights.Add(flight);
        }
    });
}

// todo move, consider shared lib 
public record GetAirportsRequest(string DepartureCountry, string ArrivalCountry);

public record GetAirportsResponse(List<Airport> DepartureAirports, List<Airport> ArrivalAirports);

public sealed class FlightsResponse
{
    [JsonPropertyName("best_flights")] public List<FlightOption> BestFlights { get; set; } = new();
}

public sealed class FlightOption
{
    [JsonIgnore] public FlightSegment? FirstFlight => Flights.FirstOrDefault();

    public List<FlightSegment> Flights { get; set; } = new();

    public int Price { get; set; }

    [JsonPropertyName("total_duration")] public int TotalDuration { get; set; }

    public string? Type { get; set; }

    [JsonPropertyName("departure_token")] public string? DepartureToken { get; set; }
}

public sealed class FlightSegment
{
    [JsonPropertyName("departure_airport")]
    public AirportInfo? DepartureAirport { get; set; }

    [JsonPropertyName("arrival_airport")] public AirportInfo? ArrivalAirport { get; set; }

    public int Duration { get; set; }

    public string? Airline { get; set; }

    [JsonPropertyName("flight_number")] public string? FlightNumber { get; set; }

    public string? Airplane { get; set; }
}

public sealed class AirportInfo
{
    public string? Name { get; set; }
    public string? Id { get; set; }
    public string? Time { get; set; }
}

public record GetFlightsRequest(
    List<string> DepartureAirports,
    List<string> ArrivalAirports,
    string? DepartureToken,
    DateOnly OutboundDate,
    DateOnly ReturnDate);