using PlantTelemetryApp.Services.Models;
using PlantTelemetryApp.Web.Contracts.Requests;

namespace PlantTelemetryApp.Services.Interfaces;

public interface ISensorService
{
    public Task<List<Sensor>> GetAllSensorsAsync();

    public Task<Sensor?> GetSensorByIdAsync(long sensorId);

    public Task<Sensor> CreateSensorAsync(CreateSensorDto sensorDto);

    public Task RemoveSensorAsync(long sensorId);
}