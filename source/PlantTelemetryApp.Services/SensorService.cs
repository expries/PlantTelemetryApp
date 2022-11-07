using Microsoft.Extensions.Logging;
using PlantTelemetryApp.DataAccess.Interfaces;
using PlantTelemetryApp.Services.Interfaces;
using PlantTelemetryApp.Services.Models;
using PlantTelemetryApp.Web.Contracts.Requests;

namespace PlantTelemetryApp.Services;

public class SensorService : ISensorService
{
    private readonly ISensorRepository _sensorRepository;
    private readonly ILogger<SensorService> _logger;

    public SensorService(ISensorRepository sensorRepository, ILogger<SensorService> logger)
    {
        ArgumentNullException.ThrowIfNull(sensorRepository);
        ArgumentNullException.ThrowIfNull(logger);
        _sensorRepository = sensorRepository;
        _logger = logger;
    }

    public async Task<List<Sensor>> GetAllSensorsAsync()
    {
        return await _sensorRepository.GetAllAsync();
    }

    public async Task<Sensor?> GetSensorByIdAsync(long sensorId)
    {
        return await _sensorRepository.GetByIdAsync(sensorId);
    }

    public async Task<Sensor> CreateSensorAsync(CreateSensorDto sensorDto)
    {
        var result = new Sensor
        {
            Location = sensorDto.Location,
            DeviceSerial = sensorDto.DeviceSerial
        };

        var sensor = await _sensorRepository.CreateAsync(result);
        return sensor;
    }

    public async Task RemoveSensorAsync(long sensorId)
    {
        var sensor =  await _sensorRepository.GetByIdAsync(sensorId);

        if (sensor is null)
        {
            return;
        }

        await _sensorRepository.RemoveAsync(sensor);
    }
}