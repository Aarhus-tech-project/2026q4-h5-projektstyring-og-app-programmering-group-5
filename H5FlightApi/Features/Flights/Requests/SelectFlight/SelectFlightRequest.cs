using H5FlightApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Features.Flights.Requests.SelectFlight;

public record SelectFlightRequest(Guid TripId);

public class SelectFlightRequestHandler(AppDbContext appDbContext)
{
    public async Task<IResult> Handle(SelectFlightRequest request, CancellationToken cancellationToken)
    {
        var trip = await appDbContext.Trips.FirstOrDefaultAsync(t => t.Id == request.TripId, cancellationToken);

        if (trip is null)
        {
            return Results.NotFound("Could not find trip");
        }
        
        
    }
}