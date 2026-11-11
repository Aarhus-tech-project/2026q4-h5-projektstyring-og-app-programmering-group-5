using H5FlightApi.Features.Flights.Requests.GetAirports;
using H5FlightApi.Features.Flights.Requests.GetFlights;
using H5FlightApi.Features.Flights.Requests.SelectFlight;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace H5FlightApi.Features.Flights.Requests;

[ApiController]
[Route("[controller]")]
[Authorize]
public class FlightsController(IMessageBus mediator) : ControllerBase
{
    [HttpGet("/airports")]
    public async Task<IResult> GetAirports([FromQuery] string departureCountry, [FromQuery] string arrivalCountry)
    {
        var request = new GetAirportsRequest(departureCountry, arrivalCountry);
        return await mediator.InvokeAsync<IResult>(request);
    }

    [HttpPost("/flights")]
    public async Task<IResult> GetFlights([FromBody] GetFlightsRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }

    [HttpPost("/flight/select")]
    public async Task<IResult> SelectFlight([FromBody] SelectFlightRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }
}