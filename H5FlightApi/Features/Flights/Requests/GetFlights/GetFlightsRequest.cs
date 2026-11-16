using System.Text.Json;
using H5FlightApi.Services.AppConfigService;
using SerpApi;

namespace H5FlightApi.Features.Flights.Requests.GetFlights;

// Todo bleh fix damn formatting
public record GetFlightsRequest(
    List<string> DepartureAirports,
    List<string> ArrivalAirports,
    string? DepartureToken,
    DateOnly OutboundDate,
    DateOnly ReturnDate);

public class GetFlightsRequestHandler(IAppConfigService appConfigService)
{
    public async Task<IResult> Handle(GetFlightsRequest request, CancellationToken cancellationToken)
    {
        // todo validering 

        using var client = new SerpApiClient(appConfigService.SerpApiApiKey);

        var parameters = new Dictionary<string, string>();

        if (request.DepartureToken is null)
        {
            parameters = new Dictionary<string, string>
            {
                ["engine"] = "google_flights",
                ["departure_id"] = string.Join(",", request.DepartureAirports.Take(9)),
                ["arrival_id"] = string.Join(",", request.ArrivalAirports.Take(9)),
                ["currency"] = "DKK",
                ["type"] = "1",
                ["outbound_date"] = request.OutboundDate.ToString("yyyy-MM-dd"),
                ["return_date"] = request.ReturnDate.ToString("yyyy-MM-dd"),
            };
        }
        else if (request.DepartureToken is not null)
        {
            parameters = new Dictionary<string, string>
            {
                ["engine"] = "google_flights",
                ["departure_id"] = string.Join(",", request.DepartureAirports.Take(9)),
                ["arrival_id"] = string.Join(",", request.ArrivalAirports.Take(9)),
                ["currency"] = "DKK",
                ["type"] = "1",
                ["outbound_date"] = request.OutboundDate.ToString("yyyy-MM-dd"),
                ["return_date"] = request.ReturnDate.ToString("yyyy-MM-dd"),
                ["departure_token"] = request.DepartureToken,
            };
        }
        else
        {
            return Results.BadRequest("Invalid args for flights");
        }

        // todo handle error when no flights are found.
        using var results = await client.SearchAsync(parameters, cancellationToken);
        var root = results.Root;

        var flights = new List<JsonElement>();

        if (root.TryGetProperty("best_flights", out var best))
        {
            flights.AddRange(best.EnumerateArray().Select(f => f.Clone()));
        }

        if (root.TryGetProperty("other_flights", out var other))
        {
            flights.AddRange(other.EnumerateArray().Select(f => f.Clone()));
        }

        return flights.Count > 0 ? Results.Ok(flights) : Results.NotFound("No flights found");
    }
}