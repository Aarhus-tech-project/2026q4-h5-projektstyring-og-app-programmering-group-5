namespace H5FlightApi.Persistence.Entities;

public class User
{
    public Guid Id { get; set; }
    public List<Trip> Trips { get; set; } = new List<Trip>();
    
    public string UserName { get; set; }
    public string Password { get; set; }
}