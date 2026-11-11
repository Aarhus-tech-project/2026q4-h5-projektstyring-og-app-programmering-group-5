using FluentValidation;
using H5FlightApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Features.Trips.Requests.GetTrips;

public record GetTripRequest(Guid Id);

public class GetTripRequestHandler(AppDbContext appDbContext, IValidator<GetTripRequest> validator)
{
    public async Task<IResult> HandleAsync(GetTripRequest request, CancellationToken cancellationToken)
    {
        var isValid = await validator.ValidateAsync(request, cancellationToken);

        if (isValid.IsValid is false)
        {
            return Results.ValidationProblemOverride(isValid.ToDictionary());
        }

        var tripToFetch = await appDbContext.Trips
            .Include(t => t.Flight)
            .Include(t => t.TripEvents).ThenInclude(te => te.Place)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (tripToFetch is null)
        {
            return Results.NotFound("Could not find trip with id: " + request.Id);
        }

        return Results.Ok(tripToFetch);
    }

    public class GetTripRequestHandlerValidator : AbstractValidator<GetTripRequest>
    {
        public GetTripRequestHandlerValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}