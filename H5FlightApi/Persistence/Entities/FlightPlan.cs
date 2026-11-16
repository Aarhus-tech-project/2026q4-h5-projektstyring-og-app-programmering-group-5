using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H5FlightApi.Persistence.Entities;

public class FlightPlan
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }
    public Trip Trip { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public string Currency { get; set; } = string.Empty;

    public int OutboundDuration { get; set; }

    public int ReturnDuration { get; set; }

    public List<Flight> Flights { get; set; } = new();
}

public class FlightPlanConfiguration : IEntityTypeConfiguration<FlightPlan>
{
    public void Configure(EntityTypeBuilder<FlightPlan> entity)
    {
        entity.HasKey(p => p.Id);

        // entity.HasIndex(p => p.TripId).IsUnique;
        //
        // entity.Property(p => p.TotalPrice)
        //     .HasPrecision(18, 2);
        //
        // entity.Property(p => p.Currency)
        //     .HasMaxLength(3)
        //     .IsRequired();

        entity.HasMany(p => p.Flights)
            .WithOne(f => f.FlightPlan)
            .HasForeignKey(f => f.FlightPlanId);
    }
}