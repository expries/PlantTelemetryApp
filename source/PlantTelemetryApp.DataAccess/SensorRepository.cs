using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlantTelemetryApp.DataAccess.DbContexts;
using PlantTelemetryApp.DataAccess.Interfaces;
using PlantTelemetryApp.Services.Models;

namespace PlantTelemetryApp.DataAccess;

public class SensorRepository : ISensorRepository
{
    private readonly TelemetryContext _telemetryContext;
    private readonly ILogger<SensorRepository> _logger;
    
    public SensorRepository(TelemetryContext telemetryContext, ILogger<SensorRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(telemetryContext);
        ArgumentNullException.ThrowIfNull(logger);
        _telemetryContext = telemetryContext;
        _logger = logger;
    }
    
    public async Task<List<Sensor>> GetAllAsync()
    {
        var sensors = await _telemetryContext.Sensors.ToListAsync();
        return sensors;
    }

    public async Task<Sensor?> GetByIdAsync(long id)
    {
        var sensor = await _telemetryContext.Sensors.FirstOrDefaultAsync(s => s.Id == id);
        return sensor;
    }

    public async Task<Sensor> CreateAsync(Sensor sensor)
    {
        var entry = await _telemetryContext.Sensors.AddAsync(sensor);
        await _telemetryContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task RemoveAsync(Sensor sensor)
    {
        _telemetryContext.Sensors.Remove(sensor);
        await _telemetryContext.SaveChangesAsync();
    }
}