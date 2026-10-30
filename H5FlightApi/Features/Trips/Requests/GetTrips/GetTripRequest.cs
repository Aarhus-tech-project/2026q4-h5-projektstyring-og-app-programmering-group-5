using H5FlightApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Features.Trips.Requests.GetTrips;

public record GetTripRequest(Guid Id);
 
public class GetTripRequestHandler(AppDbContext appDbContext)
{
    public async Task<IResult> HandleAsync(GetTripRequest request)
    {
        // todo Validate fluently 
        
        var tripToFetch = await appDbContext.Trips.FirstOrDefaultAsync(t=>t.Id == request.Id); // todo include everything 

        if (tripToFetch is null)
        {
            return Results.NotFound();
        }
        
        return Results.Ok(tripToFetch);
    }
}   

// todo ef core config and talbles for entities. 