namespace H5FlightApi.Persistence.Entities;

public class TripEvent
{
    public Guid Id { get; set; }
    
    public Guid TripId { get; set; }
    public Trip Trip { get; set; }  
    
    public Guid SightSeeingId { get; set; }
    public SightSeeing SightSeeing { get; set; }
    
    // additionaol info like time 
}