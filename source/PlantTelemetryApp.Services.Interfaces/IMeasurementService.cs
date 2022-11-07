using PlantTelemetryApp.Services.Models;

namespace PlantTelemetryApp.Services.Interfaces;

public interface IMeasurementService
{
    public Task<List<Measurement>> GetAllInTimeFrameAsync(DateTime from, DateTime to);

    public Task AddMeasurementAsync(Measurement measurement);
}