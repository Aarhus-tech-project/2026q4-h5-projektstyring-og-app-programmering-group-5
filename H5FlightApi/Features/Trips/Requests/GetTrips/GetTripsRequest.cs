using System.Security.Claims;
using H5FlightApi.Persistence;
using H5FlightApi.Services;
using H5FlightApi.Services.CurrentUserService;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Features.Trips.Requests.GetTrips;

public record GetTripsRequest();

public class GetTripsRequestHandler(CurrentUserService currentUserService, AppDbContext appDbContext)
{
    public async Task<IResult> Handle(GetTripsRequest request, CancellationToken cancellationToken)
    {
        var userIdClaim = currentUserService.UserId;

        // todo test igen nu hvor vores claims fungere anderleses.  
        if (userIdClaim is null)
        {
            return Results.Unauthorized();
        }

        var tripsToReturn = await appDbContext.Trips.Where(t => t.UserId == userIdClaim.Value).ToListAsync(cancellationToken);

        return Results.Ok(tripsToReturn);
    }
}


// todo error handling global? 