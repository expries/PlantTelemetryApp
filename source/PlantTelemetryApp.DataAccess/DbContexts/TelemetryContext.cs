using Microsoft.EntityFrameworkCore;
using PlantTelemetryApp.Services.Models;

namespace PlantTelemetryApp.DataAccess.DbContexts;

public class TelemetryContext : DbContext
{
    public DbSet<Measurement> Measurements { get; set; } = null!;
    public DbSet<Sensor> Sensors { get; set; } = null!;

    public TelemetryContext(DbContextOptions<TelemetryContext> options) : base(options)
    {
    }
}