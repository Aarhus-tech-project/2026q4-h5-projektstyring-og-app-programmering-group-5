namespace H5FlightApi.Services.AppConfigService;

public interface IAppConfigService
{
    string GeoapifyHttpClientApiKey { get; }
    string SerpApiApiKey { get; }
    void Validate();
}