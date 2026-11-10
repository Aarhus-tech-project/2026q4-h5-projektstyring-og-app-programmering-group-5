namespace H5MauiApp.ApiModels;

public class Flight
{
    public Guid Id { get; set; }

    public Trip Trip { get; set; }
    public Guid TripId { get; set; }
}