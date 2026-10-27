namespace H5FlightApi.Persistence.Entities;

public class Flight
{
    public Guid Id { get; set; }
  
    public Trip Trip { get; set; }
    public Guid TripId { get; set; }
}