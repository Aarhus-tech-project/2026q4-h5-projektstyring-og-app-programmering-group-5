using FluentValidation;
using H5FlightApi.HttpClients.Geoapify.Responses;
using H5FlightApi.Persistence;
using H5FlightApi.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Features.SightSeeing.Requests.SelectTrip;

// todo formatting 
public record SSelectPlaceForTripRequest(
    string PlaceId,
    string? AddressLine1,
    string? AddressLine2,
    string City,
    double Lat,
    double Lon,
    string? Name,
    Guid TripId);

public class SelectPlaceForTripRequestHandler(AppDbContext appDbContext)
{
    public async Task<IResult> Handle(SSelectPlaceForTripRequest request, CancellationToken cancellationToken,
        IValidator<SSelectPlaceForTripRequest> validator)
    {
        var isValid = await validator.ValidateAsync(request, cancellationToken);

        if (isValid.IsValid is false)
        {
            return Results.ValidationProblemOverride(isValid.ToDictionary());
        }

        var trip = await appDbContext.Trips.FirstOrDefaultAsync(t => t.Id == request.TripId, cancellationToken);

        if (trip is null)
        {
            return Results.NotFound("Could not find trip");
        }

        var place = await appDbContext.Places.FirstOrDefaultAsync(p => p.PlaceId == request.PlaceId, cancellationToken);

        if (place is null)
        {
            var newPlace = new Place
            {
                PlaceId = request.PlaceId,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                City = request.City,
                Lat = request.Lat,
                Lon = request.Lon,
                Name = request.Name,
            };

            await appDbContext.Places.AddAsync(newPlace, cancellationToken);
            // await appDbContext.SaveChangesAsync(cancellationToken);

            place = newPlace;
        }

        var newEvent = new TripEvent();

        place.TripEvents.Add(newEvent);
        trip.TripEvents.Add(newEvent);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return Results.Ok(newEvent);
    }

    public class SelectPlaceForTripRequestHandlerValidator : AbstractValidator<SSelectPlaceForTripRequest>
    {
        // TODO Test this validator with place request. make sure the nullalbe stuff like AddressLine1 ansd stuff is sortet oout 
        // vaidator does not align with request. 
        public SelectPlaceForTripRequestHandlerValidator()
        {
            RuleFor(r => r.PlaceId).NotEmpty();
            RuleFor(r => r.AddressLine1).NotEmpty();
            RuleFor(r => r.City).NotEmpty();
            RuleFor(r => r.Lat).NotEmpty();
            RuleFor(r => r.Lon).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.TripId).NotEmpty();
        }
    }
}