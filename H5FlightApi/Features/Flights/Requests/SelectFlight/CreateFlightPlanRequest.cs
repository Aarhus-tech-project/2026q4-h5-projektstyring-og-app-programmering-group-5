using FluentValidation;
using H5FlightApi.Persistence;
using H5FlightApi.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Features.Flights.Requests.SelectFlight;

public record CreateFlightPlanRequest(
    Guid TripId,
    decimal TotalPrice,
    string Currency,
    int OutboundDuration,
    int ReturnDuration,
    List<FlightSegmentData> OutboundFlights,
    List<FlightSegmentData> ReturnFlights);

// Just the data for each segment inside the single request.    
public record FlightSegmentData(
    string DepartureAirportCode,
    string DepartureAirportName,
    DateTime DepartureLocalTime,
    string ArrivalAirportCode,
    string ArrivalAirportName,
    DateTime ArrivalLocalTime,
    int Duration,
    string Airline,
    string FlightNumber,
    string? Airplane);

public class CreateFlightPlanRequestHandler(AppDbContext appDbContext)
{
    public async Task<IResult> Handle(CreateFlightPlanRequest request, CancellationToken cancellationToken,
        IValidator<CreateFlightPlanRequest> validator)
    {
        var isValid = await validator.ValidateAsync(request, cancellationToken);

        if (isValid.IsValid is false)
        {
            return Results.ValidationProblemOverride(isValid.ToDictionary());
        }

        var trip = await appDbContext.Trips.Include(t => t.FlightPlan).FirstOrDefaultAsync(t => t.Id == request.TripId,
            cancellationToken);

        if (trip is null)
        {
            return Results.NotFound("Could not find trip");
        }

        if (trip.FlightPlan is not null)
        {
            return Results.Conflict("Trip already has a flight plan");
        }

        var flightPlan = new FlightPlan
        {
            Trip = trip,
            TotalPrice = request.TotalPrice,
            Currency = request.Currency.ToUpperInvariant(),
            OutboundDuration = request.OutboundDuration,
            ReturnDuration = request.ReturnDuration
        };

        flightPlan.Flights = request.OutboundFlights
            .Select((flight, position) => CreateFlight(
                flight,
                FlightDirection.Outbound,
                position))
            .Concat(request.ReturnFlights.Select((flight, position) =>
                CreateFlight(
                    flight,
                    FlightDirection.Return,
                    position)))
            .ToList();

        trip.FlightPlan = flightPlan;

        await appDbContext.FlightPlans.AddAsync(
            flightPlan,
            cancellationToken);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return Results.Ok(new
        {
            FlightPlanId = flightPlan.Id,
            TripId = trip.Id
        });
    }

    private static Flight CreateFlight(
        FlightSegmentData flight,
        FlightDirection direction,
        int position)
    {
        return new Flight
        {
            Direction = direction,
            Position = position,
            DepartureAirportCode =
                flight.DepartureAirportCode.ToUpperInvariant(),
            DepartureAirportName = flight.DepartureAirportName,
            DepartureLocalTime = DateTime.SpecifyKind(
                flight.DepartureLocalTime,
                DateTimeKind.Unspecified),
            ArrivalAirportCode =
                flight.ArrivalAirportCode.ToUpperInvariant(),
            ArrivalAirportName = flight.ArrivalAirportName,
            ArrivalLocalTime = DateTime.SpecifyKind(
                flight.ArrivalLocalTime,
                DateTimeKind.Unspecified),
            Duration = flight.Duration,
            Airline = flight.Airline,
            FlightNumber = flight.FlightNumber,
            Airplane = flight.Airplane
        };
    }

    public class CreateFlightPlanRequestValidator : AbstractValidator<CreateFlightPlanRequest>
    {
        public CreateFlightPlanRequestValidator()
        {
            RuleFor(r => r.TripId).NotEmpty();

            RuleFor(r => r.TotalPrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(r => r.Currency)
                .NotEmpty()
                .Matches("^[A-Za-z]{3}$");

            RuleFor(r => r.OutboundDuration).GreaterThan(0);
            RuleFor(r => r.ReturnDuration).GreaterThan(0);

            RuleFor(r => r.OutboundFlights).NotEmpty();
            RuleFor(r => r.ReturnFlights).NotEmpty();

            RuleForEach(r => r.OutboundFlights)
                .NotNull()
                .ChildRules(ValidateSegment);

            RuleForEach(r => r.ReturnFlights)
                .NotNull()
                .ChildRules(ValidateSegment);
        }

        private static void ValidateSegment(InlineValidator<FlightSegmentData> segment)
        {
            segment.RuleFor(f => f.DepartureAirportCode)
                .NotEmpty()
                .Matches("^[A-Za-z]{3}$");

            segment.RuleFor(f => f.ArrivalAirportCode)
                .NotEmpty()
                .Matches("^[A-Za-z]{3}$");

            segment.RuleFor(f => f.DepartureAirportName).NotEmpty();
            segment.RuleFor(f => f.ArrivalAirportName).NotEmpty();
            segment.RuleFor(f => f.DepartureLocalTime).NotEmpty();
            segment.RuleFor(f => f.ArrivalLocalTime).NotEmpty();
            segment.RuleFor(f => f.Duration).GreaterThan(0);
            segment.RuleFor(f => f.Airline).NotEmpty();
            segment.RuleFor(f => f.FlightNumber).NotEmpty();
        }
    }
}