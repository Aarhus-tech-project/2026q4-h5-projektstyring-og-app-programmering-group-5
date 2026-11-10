namespace H5MauiApp.ApiModels;

public class TripEvent
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }
    public Trip Trip { get; set; }

    public Guid DatabasePlaceId { get; set; }
    public Place Place { get; set; }

    // additionaol info like time 
}