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

    [HttpGet("/flights")]
    public async Task<IResult> GetFlights([FromQuery] List<string> departureAirports, [FromQuery] List<string> arrivalAirports,
        [FromQuery] DateTime outboundDate, [FromQuery] DateTime returnDate, [FromQuery] string? departureToken = null)
    {
        // outboundDate = DateTime.UtcNow;
        // returnDate = DateTime.UtcNow.AddDays(7);

        var request = new GetFlightsRequest(departureAirports, arrivalAirports, departureToken, outboundDate, returnDate);
        return await mediator.InvokeAsync<IResult>(request);
    }

    [HttpPost("/flight/select")]
    public async Task<IResult> SelectFlight([FromBody] SelectFlightRequest request)
    {
        return await mediator.InvokeAsync<IResult>(request);
    }
}