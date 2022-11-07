using Microsoft.Extensions.Logging;
using PlantTelemetryApp.DataAccess.Interfaces;
using PlantTelemetryApp.Services.Interfaces;
using PlantTelemetryApp.Services.Models;

namespace PlantTelemetryApp.Services;

public class MeasurementService : IMeasurementService
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly ILogger<MeasurementService> _logger;

    public MeasurementService(IMeasurementRepository measurementRepository, ILogger<MeasurementService> logger)
    {
        ArgumentNullException.ThrowIfNull(measurementRepository);
        ArgumentNullException.ThrowIfNull(logger);
        _measurementRepository = measurementRepository;
        _logger = logger;
    }
    
    public async Task<List<Measurement>> GetAllInTimeFrameAsync(DateTime from, DateTime to)
    {
        return await _measurementRepository.GetAllInTimeFrameAsync(from, to);
    }

    public async Task AddMeasurementAsync(Measurement measurement)
    {
        await _measurementRepository.AddAsync(measurement);
    }
}