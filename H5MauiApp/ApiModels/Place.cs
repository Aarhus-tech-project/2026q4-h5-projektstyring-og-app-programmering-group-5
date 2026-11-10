namespace H5MauiApp.ApiModels;

public class Place
{
    public Guid DatabasePlaceId { get; set; }
    public string PlaceId { get; set; }
    public string? Name { get; set; }
    public string City { get; set; } = string.Empty;
    public double Lon { get; set; }
    public double Lat { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public List<TripEvent> TripEvents { get; set; } = new List<TripEvent>();
}