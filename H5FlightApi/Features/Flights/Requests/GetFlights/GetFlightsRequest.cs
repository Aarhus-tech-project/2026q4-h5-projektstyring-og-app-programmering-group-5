using SerpApi;

namespace H5FlightApi.Features.Flights.Requests.GetFlights;

public record GetFlightsRequest(
    List<string> DepartureAirports,
    List<string> ArrivalAirports,
    string? DepartureToken,
    DateOnly OutboundDate,
    DateOnly ReturnDate);

public class GetFlightsRequestHandler()
{
    public async Task<IResult> Handle(GetFlightsRequest request, CancellationToken cancellationToken)
    {
        // todo validering 
        // todo smid cliet id ud i config. 
        using var client = new SerpApiClient("992d7b46b506781711c6707a321a9d7d1df76c50c29f63258e577e308e6e54c0");

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

        // todo this can fail if there are no flights? handel it and reutnr not found responce. 

        // todo hvorfor fuck kan jeg ikeke debug det her lort. 
        // todo handle error here with no results, idk why i jsut inta crashes. 
        using var results = await client.SearchAsync(parameters);
        var bestFlights = results.Root.GetProperty("best_flights").Clone();

        return Results.Ok(bestFlights);
    }
}