using System.Text.Json.Serialization;

namespace H5FlightApi.HttpClients.Geoapify.Responses;

public class LocationResponse
{
    [JsonPropertyName("results")]
    public List<LocationResult> Results { get; set; }
}

public class LocationResult
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("postcode")]
    public string Postcode { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("formatted")]
    public string Formatted { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("result_type")]
    public string ResultType { get; set; }

    [JsonPropertyName("place_id")]
    public string PlaceId { get; set; }
}