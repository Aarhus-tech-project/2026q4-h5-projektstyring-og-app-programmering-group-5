using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H5FlightApi.Persistence.Entities;

public class Flight
{
    public Guid Id { get; set; }

    public Trip Trip { get; set; }
    public Guid TripId { get; set; }
}

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> entity)
    {
        entity.HasKey(f => f.Id);
    }
}