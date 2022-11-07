using PlantTelemetryApp.Services.Models;

namespace PlantTelemetryApp.DataAccess.Interfaces;

public interface IMeasurementRepository
{
    public Task<Measurement> AddAsync(Measurement measurement);

    public Task<List<Measurement>> GetAllInTimeFrameAsync(DateTime from, DateTime to);
}