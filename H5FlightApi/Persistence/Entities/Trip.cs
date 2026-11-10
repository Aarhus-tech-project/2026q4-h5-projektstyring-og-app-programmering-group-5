using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H5FlightApi.Persistence.Entities;

public class Trip
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid? FlightId { get; set; }
    public Flight? Flight { get; set; }

    public List<TripEvent> TripEvents { get; set; } = new List<TripEvent>();


    public string Title { get; set; } = string.Empty;
}

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> entity)
    {
        entity.HasKey(t => t.Id);

        entity.HasMany(t => t.TripEvents).WithOne(t => t.Trip).HasForeignKey(t => t.TripId);

        entity.HasOne(t => t.User).WithMany(u => u.Trips).HasForeignKey(t => t.UserId);

        // todo fatter seriøst ikke forskellen på principleke og foien key i et til et forhold 
        // todo spørg kenneth.  
        entity.HasOne(t => t.Flight)
            .WithOne(f => f.Trip)
            .HasForeignKey<Trip>(t => t.FlightId)
            .HasPrincipalKey<Flight>(f => f.Id);
    }
}