namespace H5FlightApi.Persistence.Entities;

public class SightSeeing
{
    public Guid Id { get; set; }
    public List<TripEvent> TripEvents { get; set; } = new List<TripEvent>(); 
} 