namespace H5MauiApp.ApiModels;

public sealed class Airport
{
    public long Id { get; set; }
    public string Ident { get; set; } = "";
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int? ElevationFeet { get; set; }
    public string Continent { get; set; } = "";
    public string IsoCountry { get; set; } = "";
    public string IsoRegion { get; set; } = "";
    public string Municipality { get; set; } = "";
    public bool HasScheduledService { get; set; }
    public string IcaoCode { get; set; } = "";
    public string IataCode { get; set; } = "";
    public string GpsCode { get; set; } = "";
    public string LocalCode { get; set; } = "";
}

// todo make sahred lib 