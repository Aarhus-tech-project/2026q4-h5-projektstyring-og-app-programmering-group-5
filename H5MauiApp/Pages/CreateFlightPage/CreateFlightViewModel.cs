using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using H5MauiApp.ApiModels;
using H5MauiApp.Data;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Pages.SelectFlightPage;
using H5MauiApp.Services.AlertService;

namespace H5MauiApp.Pages.CreateFlightPage;

[QueryProperty(nameof(TripId), "TripId")]
public partial class CreateFlightViewModel(IErrorHandler errorHandler, HttpClient httpClient, IAlertService alertService) : ObservableObject
{
    // Todo husk at dobblet tjekke der bliver retrned på dialoger med alert errors 

    [ObservableProperty] private Country? departureCountry;
    [ObservableProperty] private Country? destinationCountry;
    [ObservableProperty] private DateTime departureDate = DateTime.Today;
    [ObservableProperty] private DateTime returnDate = DateTime.Today;
    [ObservableProperty] private Guid tripId;

    public GetFlightsRequest? GetFlightsRequest = null;

    public ObservableCollection<FlightOption> BestFlights { get; } = new();
    public ObservableCollection<FlightOption> BestReturningFlights { get; } = new();

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(ConfirmTripCommand))]
    private FlightOption? selectedDepartureFlight;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(ConfirmTripCommand))]
    private FlightOption? selectedReturnFlight;


    public IReadOnlyList<Country> Countries { get; } =
        CountryData.Countries.OrderBy(country => country.Name, StringComparer.OrdinalIgnoreCase).ToArray();

    // todo is budy and cancelation token stuff, handle smeone spamming the buttons 

    // todo ville være  nice hvis man selc kunne vælge lufthavn i stedet fro at få alle de store og så tage de 9 første. 
    // men det er fint for nu 

    [RelayCommand]
    public async Task GetAirports() => await errorHandler.Guard(async () =>
    {
        // todo insane god method, consider using services for this, or http client wrappers, 
        var getAirportsResponse = await httpClient.GetAsync(
            $"/airports?departureCountry={DepartureCountry?.Code}&arrivalCountry={DestinationCountry?.Code}");

        if (getAirportsResponse.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlertAsync(getAirportsResponse);
            return;
        }

        var airports = await getAirportsResponse.Content.ReadFromJsonAsync<GetAirportsResponse>();

        if (airports is null || airports.ArrivalAirports.Count == 0 || airports.DepartureAirports.Count == 0)
        {
            await alertService.ShowAlertAsync(AlertTitle.Error, "Could not get airports");
            return;
        }

        var departureCodes = airports.DepartureAirports.Select(a => a.IataCode).ToList();
        var destinationCodes = airports.ArrivalAirports.Select(a => a.IataCode).ToList();


        // todo vi skal have is busy indicator på 
        var getFlightsRequest = new GetFlightsRequest(departureCodes, destinationCodes,
            null, DateOnly.FromDateTime(DepartureDate), DateOnly.FromDateTime(ReturnDate));

        // store for later usage. 
        GetFlightsRequest = getFlightsRequest;

        // // todo serpaip can throw erros if nothing is fond with request. 
        // what to do if returning flight cant be found on a given date, suggest oter flights? would also consue credits. 

        var getFlightsResponse = await httpClient.PostAsJsonAsync("/flights", getFlightsRequest);
        // var getFlightsResponse = await httpClient.GetAsync(
        //     $"/flights?{departureCodes}&{arrivalCodes}" +
        //     $"&outboundDate={DateOnly.FromDateTime(DepartureDate):yyyy-MM-dd}" +
        //     $"&returnDate={DateOnly.FromDateTime(ReturnDate):yyyy-MM-dd}");

        if (getFlightsResponse.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlertAsync(getFlightsResponse);
            return;
        }

        var flights = await getFlightsResponse.Content.ReadFromJsonAsync<List<FlightOption>>() ?? new List<FlightOption>();

        if (flights is null || flights.Count == 0)
        {
            await alertService.ShowAlertAsync(AlertTitle.Error, "Could not get flights");
            return;
        }

        SelectedDepartureFlight = null;
        BestFlights.Clear();

        foreach (var flight in flights)
        {
            BestFlights.Add(flight);
        }

        // todo select flight popup 
    });

    [RelayCommand]
    public async Task GetReturningFlight(FlightOption flightOption) => await errorHandler.Guard(async () =>
    {
        if (GetFlightsRequest is null)
        {
            await alertService.ShowAlertAsync(AlertTitle.Error, "get flights request was null");
            return;
        }

        var getFlightsResponse = await httpClient.PostAsJsonAsync("/flights",
            new GetFlightsRequest(GetFlightsRequest.DepartureAirports, GetFlightsRequest.ArrivalAirports, flightOption.DepartureToken,
                GetFlightsRequest.OutboundDate, GetFlightsRequest.ReturnDate));

        if (getFlightsResponse.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlertAsync(getFlightsResponse);
            return;
        }

        var flights = await getFlightsResponse.Content.ReadFromJsonAsync<List<FlightOption>>() ?? new List<FlightOption>();

        if (flights is null || flights.Count == 0)
        {
            await alertService.ShowAlertAsync(AlertTitle.Error, "Could not get return flights");
            return;
        }

        BestReturningFlights.Clear();

        foreach (var flight in flights)
        {
            BestReturningFlights.Add(flight);
        }

        // todo reseach calling navigation method inside of relay command how does that work? and when does this task retunr and fisnish; 
        // GetReturningFlight calls await on navigation, does GetReturningFlight end right away or does it awat ant technally stay smewher util lthe enxt page isdestroyed?
        // todo no need to gaurd here 
        // await GotoSelectFlightView();
    });

    partial void OnSelectedDepartureFlightChanged(FlightOption? value)
    {
        if (value is null) return;

        // a new departure flight invalidates the old return flights
        SelectedReturnFlight = null;
        BestReturningFlights.Clear();

        GetReturningFlightCommand.Execute(value);
    }

    [RelayCommand(CanExecute = nameof(CanConfirmTrip))]
    public async Task ConfirmTrip() => await errorHandler.Guard(async () =>
    {
        var outboundFlight = SelectedDepartureFlight;
        var returnFlight = SelectedReturnFlight;

        if (outboundFlight is null || returnFlight is null)
        {
            await alertService.ShowAlertAsync(AlertTitle.Error, "Select both departure and return flights");

            return;
        }

        if (TripId == Guid.Empty)
        {
            await alertService.ShowAlertAsync(
                AlertTitle.Error,
                "No trip selected");

            return;
        }

        var request = new CreateFlightPlanRequest(
            TripId,
            returnFlight.Price,
            "DKK",
            outboundFlight.TotalDuration,
            returnFlight.TotalDuration,
            outboundFlight.Flights.Select(MapFlightSegment).ToList(),
            returnFlight.Flights.Select(MapFlightSegment).ToList());

        using var response = await httpClient.PostAsJsonAsync(
            "/flight/select",
            request);

        if (response.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlertAsync(response);
            return;
        }

        await Shell.Current.GoToAsync("..");
    });

    private static FlightSegmentData MapFlightSegment(FlightSegment flight)
    {
        var departure = flight.DepartureAirport
                        ?? throw new InvalidOperationException(
                            "Flight is missing its departure airport");

        var arrival = flight.ArrivalAirport
                      ?? throw new InvalidOperationException(
                          "Flight is missing its arrival airport");

        if (DateTime.TryParseExact(
                departure.Time,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var departureTime) is false)
        {
            throw new InvalidOperationException(
                "Flight has an invalid departure time");
        }

        if (DateTime.TryParseExact(
                arrival.Time,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var arrivalTime) is false)
        {
            throw new InvalidOperationException(
                "Flight has an invalid arrival time");
        }

        return new FlightSegmentData(
            departure.Id ?? string.Empty,
            departure.Name ?? string.Empty,
            departureTime,
            arrival.Id ?? string.Empty,
            arrival.Name ?? string.Empty,
            arrivalTime,
            flight.Duration,
            flight.Airline ?? string.Empty,
            flight.FlightNumber ?? string.Empty,
            flight.Airplane);
    }

    private bool CanConfirmTrip() => SelectedDepartureFlight is not null && SelectedReturnFlight is not null;

    // todo hvad hvis en method bliver kaldt både fra en method der er guarded og fra en der ikke er? så bliver man jo tvunget til at dobble catche n af stederne. 
    // public async Task GotoSelectFlightView(FlightOption departureFlight, FlightOption returningflight)
    // {
    //     var parameters = new ShellNavigationQueryParameters
    //     {
    //         ["DepartureFlight"] = departureFlight,
    //         ["ReturningFlight"] = returningflight
    //     };
    //
    //     await Shell.Current.GoToAsync(nameof(SelectFlightView), parameters);
    // }
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

    [JsonIgnore] public FlightSegment? LastFlight => Flights.LastOrDefault();

    [JsonIgnore]
    public string StopsDescription => Flights.Count switch
    {
        0 => "No flight segments",
        1 => "Nonstop",
        2 => "1 connection",
        _ => $"{Flights.Count - 1} connections"
    };

    public List<FlightSegment> Flights { get; set; } = new();

    public List<FlightLayover> Layovers { get; set; } = new();

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

public sealed class FlightLayover
{
    public string? Name { get; set; }

    public string? Id { get; set; }

    public int Duration { get; set; }

    public bool Overnight { get; set; }
}

public record GetFlightsRequest(
    List<string> DepartureAirports,
    List<string> ArrivalAirports,
    string? DepartureToken,
    DateOnly OutboundDate,
    DateOnly ReturnDate);

public record CreateFlightPlanRequest(
    Guid TripId,
    decimal TotalPrice,
    string Currency,
    int OutboundDuration,
    int ReturnDuration,
    List<FlightSegmentData> OutboundFlights,
    List<FlightSegmentData> ReturnFlights);

// Just the data for each segment inside the single request.
public record FlightSegmentData(
    string DepartureAirportCode,
    string DepartureAirportName,
    DateTime DepartureLocalTime,
    string ArrivalAirportCode,
    string ArrivalAirportName,
    DateTime ArrivalLocalTime,
    int Duration,
    string Airline,
    string FlightNumber,
    string? Airplane);