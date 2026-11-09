using SerpApi;

namespace H5FlightApi.Features.Flights.Requests.GetFlights;

public record GetFlightsRequest(
    List<string> DepartureAirports,
    List<string> ArrivalAirports,
    string? DepartureToken,
    DateTime OutboundDate,
    DateTime ReturnDate);

public class GetFlightsRequestHandler()
{
    public async Task<IResult> Handle(GetFlightsRequest request, CancellationToken cancellationToken)
    {
        // todo validering 
        using var client = new SerpApiClient("992d7b46b506781711c6707a321a9d7d1df76c50c29f63258e577e308e6e54c0");

        var parameters = new Dictionary<string, string>();

        if (request.DepartureToken is null)
        {
            parameters = new Dictionary<string, string>
            {
                ["engine"] = "google_flights",
                ["departure_id"] = string.Join(",", request.DepartureAirports),
                ["arrival_id"] = string.Join(",", request.ArrivalAirports),
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
                ["departure_id"] = string.Join(",", request.DepartureAirports),
                ["arrival_id"] = string.Join(",", request.ArrivalAirports),
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

        using var results = await client.SearchAsync(parameters);
        var bestFlights = results.Root.GetProperty("best_flights").Clone();

        return Results.Ok(bestFlights);
    }
}