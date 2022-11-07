using PlantTelemetryApp.Services.Models;

namespace PlantTelemetryApp.DataAccess.Interfaces;

public interface ISensorRepository
{
    public Task<List<Sensor>> GetAllAsync();
    
    public Task<Sensor?> GetByIdAsync(long id);

    public Task<Sensor> CreateAsync(Sensor sensor);

    public Task RemoveAsync(Sensor sensor);
}