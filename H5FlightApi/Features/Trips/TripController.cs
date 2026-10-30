using H5FlightApi.Features.Trips.Requests.GetTrips;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace H5FlightApi.Features.Trips;

// todo add auth 
[ApiController]
[Route("[controller]")]
public class TripController(IMessageBus mediator)
{
    [HttpGet("/{tripId}")]
    public async Task<IResult> GetTrip([FromRoute] Guid tripId)
    {
        var request = new GetTripRequest(tripId);
        return await mediator.InvokeAsync<IResult>(request);
    }
}   