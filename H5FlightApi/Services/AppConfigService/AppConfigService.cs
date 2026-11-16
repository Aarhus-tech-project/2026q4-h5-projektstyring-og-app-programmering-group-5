namespace H5FlightApi.Services.AppConfigService;

public class AppConfigService(IConfiguration configuration) : IAppConfigService
{
    public string GeoapifyHttpClientApiKey { get; } = configuration["GeoApi:ApiKey"] ?? string.Empty;
    public string SerpApiApiKey { get; } = configuration["SerpApi:ApiKey"] ?? string.Empty;

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(GeoapifyHttpClientApiKey))
        {
            throw new Exception("Geoapify API Key is missing");
        }

        if (string.IsNullOrWhiteSpace(SerpApiApiKey))
        {
            throw new Exception("Serp API Key is missing");
        }
    }
}