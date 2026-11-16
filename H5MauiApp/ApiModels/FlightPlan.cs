namespace H5MauiApp.ApiModels;

public class FlightPlan
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }
    public Trip Trip { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public string Currency { get; set; } = string.Empty;

    public int OutboundDuration { get; set; }

    public int ReturnDuration { get; set; }

    public List<Flight> Flights { get; set; } = new();
}