namespace H5FlightApi.Persistence.Entities;

public class Trip
{
    public Guid Id { get; set; }
    
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid? FlightId { get; set; }
    public Flight? Flight { get; set; }

    public List<TripEvent> TripEvents { get; set; } = new List<TripEvent>();
}