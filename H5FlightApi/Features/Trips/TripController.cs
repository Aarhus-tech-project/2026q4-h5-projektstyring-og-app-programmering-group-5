using System.Security.Claims;
using H5FlightApi.Features.Trips.Requests.CreateTrip;
using H5FlightApi.Features.Trips.Requests.GetTrips;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace H5FlightApi.Features.Trips;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TripController(IMessageBus mediator) : ControllerBase
{
    [HttpGet("/{tripId}")]
    public async Task<IResult> GetTrip([FromRoute] Guid tripId)
    {
        var request = new GetTripRequest(tripId);
        return await mediator.InvokeAsync<IResult>(request);
    }

    [HttpGet]
    public async Task<IResult> GetTrips()
    {
        var request = new GetTripsRequest();
        return await mediator.InvokeAsync<IResult>(request);
    }

    [HttpPost]
    public async Task<IResult> CreateTrip([FromBody] CreateTripRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }
}