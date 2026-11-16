using H5FlightApi.Features.SightSeeing.Requests.GetPlacesForCity;
using H5FlightApi.Features.SightSeeing.Requests.SelectTrip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace H5FlightApi.Features.SightSeeing;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SightSeeingController(IMessageBus mediator) : ControllerBase
{
    // todo sussy to use http post for "get" requests. Use query params -> create request from params -> invoke handler.
    [HttpPost("/GetPlacesForCity")]
    public async Task<IResult> GetPlacesForCity([FromBody] GetPlacesForCityRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }

    // todo find convention to follow? rest? something else? 
    [HttpPost("/SelectPlaceForTrip")]
    public async Task<IResult> SelectPlaceForTrip([FromBody] SSelectPlaceForTripRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }
}