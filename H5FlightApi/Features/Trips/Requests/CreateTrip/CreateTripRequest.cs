using H5FlightApi.Persistence.Entities;
using Microsoft.Build.Framework;

namespace H5FlightApi.Features.Trips.Requests.CreateTrip;

public record CreateTripRequest();

public class CreateTripRequestHandler()
{
    public async Task Handle(CreateTripRequest request)
    {
        // todo need factroy 
        var newTrip = new Trip
        {
            UserId = SdkResultFactory, // todo form token? 
            
        };
    }
}