using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H5FlightApi.Persistence.Entities;

public enum FlightDirection
{
    Outbound,
    Return
}

public class Flight
{
    public Guid Id { get; set; }

    public Guid FlightPlanId { get; set; }
    public FlightPlan FlightPlan { get; set; } = null!;

    public FlightDirection Direction { get; set; }

    public int Position { get; set; }

    public string DepartureAirportCode { get; set; } = string.Empty;

    public string DepartureAirportName { get; set; } = string.Empty;

    public DateTime DepartureLocalTime { get; set; }

    public string ArrivalAirportCode { get; set; } = string.Empty;

    public string ArrivalAirportName { get; set; } = string.Empty;

    public DateTime ArrivalLocalTime { get; set; }

    public int Duration { get; set; }

    public string Airline { get; set; } = string.Empty;

    public string FlightNumber { get; set; } = string.Empty;

    public string? Airplane { get; set; }
}

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> entity)
    {
        entity.HasKey(f => f.Id);

        entity
            .Property(f => f.DepartureLocalTime)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(f => f.ArrivalLocalTime)
            .HasColumnType("timestamp without time zone");

        // entity.HasIndex(f => new
        // {
        //     f.FlightPlanId,
        //     f.Direction,
        //     f.Position
        // }).IsUnique();
        //
        // entity.Property(f => f.DepartureAirportCode)
        //     .HasMaxLength(3)
        //     .IsRequired();
        //
        // entity.Property(f => f.ArrivalAirportCode)
        //     .HasMaxLength(3)
        //     .IsRequired();
    }
}