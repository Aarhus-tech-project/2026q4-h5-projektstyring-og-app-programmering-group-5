using FluentValidation;
using H5FlightApi.Persistence;
using H5FlightApi.Persistence.Entities;
using H5FlightApi.Services;
using H5FlightApi.Services.CurrentUserService;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Features.Trips.Requests.CreateTrip;

public record CreateTripRequest(string Title);

public class CreateTripRequestHandler(ICurrentUserService currentUserService, AppDbContext appDbContext)
{
    public async Task<IResult> Handle(CreateTripRequest request, CancellationToken cancellationToken)
    {
        var userIdClaim = currentUserService.UserId;

        if (userIdClaim is null)
        {
            return Results.Unauthorized();
        }

        var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userIdClaim.Value, cancellationToken);

        if (user is null)
        {
            return Results.NotFound();
        }

        var newTrip = new Trip
        {
            UserId = userIdClaim.Value,
            Title = request.Title
        };

        user.Trips.Add(newTrip);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return Results.Ok(newTrip);
    }

    public class CreateTripRequestValidator : AbstractValidator<CreateTripRequest>
    {
        public CreateTripRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}