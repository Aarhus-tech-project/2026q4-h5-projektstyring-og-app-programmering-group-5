namespace H5FlightApi.Services.AppConfigService;

public class AppConfigService(IConfiguration configuration) : IAppConfigService
{
    public string GeoapifyHttpClientApiKey { get; } = configuration["GeoApi:ApiKey"] ?? string.Empty;

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(GeoapifyHttpClientApiKey))
        {
            throw new Exception("Geoapify API Key is missing");
        }
    }
}