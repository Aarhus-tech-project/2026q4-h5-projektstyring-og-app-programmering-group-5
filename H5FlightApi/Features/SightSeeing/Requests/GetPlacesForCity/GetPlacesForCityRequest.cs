using FluentValidation;
using H5FlightApi.Features.SightSeeing.Requests.SelectTrip;
using H5FlightApi.HttpClients.Geoapify.GeoapifyHttpClient;
using H5FlightApi.HttpClients.Geoapify.Responses;

namespace H5FlightApi.Features.SightSeeing.Requests.GetPlacesForCity;

public record GetPlacesForCityRequest(string City, string Country);

public class GetPlacesForCityRequestHandler(GeoapifyHttpClient geoapifyHttpClient, IValidator<GetPlacesForCityRequest> validator)
{
    public async Task<IResult> Handle(GetPlacesForCityRequest request, CancellationToken cancellationToken)
    {
        var isValid = await validator.ValidateAsync(request);

        if (!isValid.IsValid)
        {
            return Results.BadRequest(isValid);
        }

        LocationResponse? cityInfo = await geoapifyHttpClient.GetCityInfo(request.City, request.Country);

        if (cityInfo is null)
        {
            return Results.NotFound("Could not find city in country");
        }

        GeoJsonFeatureCollection? pointsOfInterrest = await geoapifyHttpClient.GetPointsOfInterestInCity(cityInfo.Results.First().PlaceId);

        if (pointsOfInterrest is null)
        {
            return Results.NotFound("Could not find pointsOfInterrest");
        }

        var places = PlaceConverter.GetPlaces(pointsOfInterrest);

        return Results.Ok(places);
    }

    public class GetPlacesForCityRequestHandlerValidator : AbstractValidator<GetPlacesForCityRequest>
    {
        public GetPlacesForCityRequestHandlerValidator()
        {
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
        }
    }
}

// todo kunne lave dtoer til responses 
// todo ryd op i rogram fil. 