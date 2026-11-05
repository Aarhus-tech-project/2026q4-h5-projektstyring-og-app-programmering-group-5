using System.Text.Json.Serialization;

namespace H5FlightApi.HttpClients.Geoapify.Responses;

public class GeoJsonFeatureCollection
{
    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("features")] public List<GeoJsonFeature> Features { get; set; }
}

public class GeoJsonFeature
{
    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("properties")] public FeatureProperties Properties { get; set; }
}

public class FeatureProperties
{
    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("country")] public string Country { get; set; }

    [JsonPropertyName("country_code")] public string CountryCode { get; set; }

    [JsonPropertyName("state")] public string State { get; set; }

    [JsonPropertyName("city")] public string City { get; set; }

    [JsonPropertyName("municipality")] public string? Municipality { get; set; }

    [JsonPropertyName("postcode")] public string Postcode { get; set; }

    [JsonPropertyName("suburb")] public string? Suburb { get; set; }

    [JsonPropertyName("quarter")] public string? Quarter { get; set; }

    [JsonPropertyName("street")] public string? Street { get; set; }

    [JsonPropertyName("iso3166_2")] public string Iso31662 { get; set; }

    [JsonPropertyName("lon")] public double Lon { get; set; }

    [JsonPropertyName("lat")] public double Lat { get; set; }

    [JsonPropertyName("formatted")] public string Formatted { get; set; }

    [JsonPropertyName("address_line1")] public string? AddressLine1 { get; set; }

    [JsonPropertyName("address_line2")] public string? AddressLine2 { get; set; }
    //
    // [JsonPropertyName("categories")] public List<string> Categories { get; set; }
    //
    // [JsonPropertyName("details")] public List<string> Details { get; set; }

    [JsonPropertyName("distance")] public int Distance { get; set; }

    [JsonPropertyName("place_id")] public string PlaceId { get; set; }

    [JsonPropertyName("website")] public string? Website { get; set; }

    [JsonPropertyName("opening_hours")] public string? OpeningHours { get; set; }
}