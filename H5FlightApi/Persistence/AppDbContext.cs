using H5FlightApi.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}