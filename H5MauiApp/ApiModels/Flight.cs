namespace H5MauiApp.ApiModels;

public class Flight
{
    public Guid Id { get; set; }

    public Guid FlightPlanId { get; set; }
    public FlightPlan FlightPlan { get; set; } = null!;

    public FlightDirection Direction { get; set; }

    public int Position { get; set; }

    public string DepartureAirportCode { get; set; } = string.Empty;

    public string DepartureAirportName { get; set; } = string.Empty;

    public DateTime DepartureLocalTime { get; set; }

    public string ArrivalAirportCode { get; set; } = string.Empty;

    public string ArrivalAirportName { get; set; } = string.Empty;

    public DateTime ArrivalLocalTime { get; set; }

    public int Duration { get; set; }

    public string Airline { get; set; } = string.Empty;

    public string FlightNumber { get; set; } = string.Empty;

    public string? Airplane { get; set; }
}

public enum FlightDirection
{
    Outbound,
    Return
}