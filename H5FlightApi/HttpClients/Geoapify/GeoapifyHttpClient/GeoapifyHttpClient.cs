using H5FlightApi.HttpClients.Geoapify.Responses;
using H5FlightApi.Services.AppConfigService;

namespace H5FlightApi.HttpClients.Geoapify.GeoapifyHttpClient;

// todo thi does not chnage the actuall http client and its jsut ar egular client being injectet, 
// its not a uniqe client for itself, i dont think, research. 
public class GeoapifyHttpClient : IGeoapifyHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GeoapifyHttpClient(HttpClient httpClient, IAppConfigService appConfigService)
    {
        _httpClient = httpClient;
        _apiKey = appConfigService.GeoapifyHttpClientApiKey;
    }

    public async Task<LocationResponse?> GetCityInfo(string city, string country)
    {
        string requestUri = $"https://api.geoapify.com/v1/geocode/search?text={city}, {country}&type=city&format=json&limit=1&apiKey={_apiKey}";
        var result = await _httpClient.GetAsync(requestUri);

        LocationResponse? content = await result.Content.ReadFromJsonAsync<LocationResponse>();

        return content;
    }

    public async Task<GeoJsonFeatureCollection?> GetPointsOfInterestInCity(string placeId)
    {
        string requestUri = $"https://api.geoapify.com/v2/places?categories=tourism&filter=place:{placeId}&limit=20&apiKey={_apiKey}";

        var result = await _httpClient.GetAsync(requestUri);

        GeoJsonFeatureCollection? content = await result.Content.ReadFromJsonAsync<GeoJsonFeatureCollection>();

        return content;
    }
}