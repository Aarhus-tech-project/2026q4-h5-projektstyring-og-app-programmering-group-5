using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H5FlightApi.Persistence.Entities;

public class Place
{
    public Guid DatabasePlaceId { get; set; } // todo find id navne løsning her 
    public string PlaceId { get; set; }
    public string? Name { get; set; }
    public string City { get; set; } = string.Empty;
    public double Lon { get; set; }
    public double Lat { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public List<TripEvent> TripEvents { get; set; } = new List<TripEvent>();
}

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> entity)
    {
        entity.HasKey(p => p.DatabasePlaceId);
    }
}