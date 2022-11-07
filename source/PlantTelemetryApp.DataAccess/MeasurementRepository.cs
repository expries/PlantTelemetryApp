using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlantTelemetryApp.DataAccess.DbContexts;
using PlantTelemetryApp.DataAccess.Interfaces;
using PlantTelemetryApp.Services.Models;

namespace PlantTelemetryApp.DataAccess;

public class MeasurementRepository : IMeasurementRepository
{
    private readonly TelemetryContext _telemetryContext;
    private readonly ILogger<MeasurementRepository> _logger;
    
    public MeasurementRepository(TelemetryContext telemetryContext, ILogger<MeasurementRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(telemetryContext);
        ArgumentNullException.ThrowIfNull(logger);
        _telemetryContext = telemetryContext;
        _logger = logger;
    }
    
    public async Task<Measurement> AddAsync(Measurement measurement)
    {
        var entry = await _telemetryContext.Measurements.AddAsync(measurement);
        await _telemetryContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<List<Measurement>> GetAllInTimeFrameAsync(DateTime from, DateTime to)
    {
        var measurements = await _telemetryContext.Measurements
            .Where(m => from >= m.Metadata.Timestamp && m.Metadata.Timestamp <= to)
            .ToListAsync();

        return measurements;
    }
}