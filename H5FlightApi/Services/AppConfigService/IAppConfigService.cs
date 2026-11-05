namespace H5FlightApi.Services.AppConfigService;

public interface IAppConfigService
{
    string GeoapifyHttpClientApiKey { get; }
    void Validate();
}