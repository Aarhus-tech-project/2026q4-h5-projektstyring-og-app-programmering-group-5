using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H5FlightApi.Persistence.Entities;

public class TripEvent
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }
    public Trip Trip { get; set; }

    public Guid DatabasePlaceId { get; set; }
    public Place Place { get; set; }

    // additionaol info like time 
}

public class TripEventConfiguration : IEntityTypeConfiguration<TripEvent>
{
    public void Configure(EntityTypeBuilder<TripEvent> entity)
    {
        entity.HasKey(t => t.Id);
        entity.HasOne(t => t.Place).WithMany(p => p.TripEvents).HasForeignKey(t => t.DatabasePlaceId);
    }
}