using H5FlightApi.HttpClients.Geoapify.Responses;
using H5FlightApi.Persistence.Entities;

namespace H5FlightApi.Converters;

public static class PlaceConverter
{
    public static List<Place> GetPlaces(GeoJsonFeatureCollection collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        return collection.Features.Select(feature => new Place
        {
            PlaceId = feature.Properties.PlaceId,
            Name = feature.Properties.Name,
            City = feature.Properties.City,
            Lon = feature.Properties.Lon,
            Lat = feature.Properties.Lat,
            AddressLine1 = feature.Properties.AddressLine1,
            AddressLine2 = feature.Properties.AddressLine2
        }).ToList();
    }
}