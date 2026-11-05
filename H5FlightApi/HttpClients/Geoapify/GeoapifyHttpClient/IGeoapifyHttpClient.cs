using H5FlightApi.HttpClients.Geoapify.Responses;

namespace H5FlightApi.HttpClients.Geoapify.GeoapifyHttpClient;

public interface IGeoapifyHttpClient
{
    Task<LocationResponse?> GetCityInfo(string city, string country);

    Task<GeoJsonFeatureCollection?> GetPointsOfInterestInCity(string placeId);
}