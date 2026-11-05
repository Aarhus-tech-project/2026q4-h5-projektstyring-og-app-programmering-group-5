using H5FlightApi.Features.SightSeeing.Requests.GetPlacesForCity;
using H5FlightApi.Features.SightSeeing.Requests.SelectTrip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace H5FlightApi.Features.SightSeeing;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class SightSeeingController(IMessageBus mediator) : ControllerBase // TODO hvad gør det? 
{
    // TODO: Spørg kenneth hvad han sys om get requests som er posts fordi body, kan også lave query params og lave en request d fra det som jeg skan skyde afsted.
    // todo skal lige fine en conventi der gir menign at følge. 
    [HttpPost("/GetPlacesForCity")]
    public async Task<IResult> GetPlacesForCity([FromBody] GetPlacesForCityRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }

    // todo lav get requests om til at bruge queries. 

    // todo find convetion for routes to follow 
    [HttpPost("/SelectPlaceForTrip")]
    public async Task<IResult> SelectPlaceForTrip([FromBody] SSelectPlaceForTripRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }
}