using H5FlightApi.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<TripEvent> TripEvents { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}