using Microsoft.AspNetCore.Mvc;
using PlantTelemetryApp.Services.Interfaces;
using PlantTelemetryApp.Web.Contracts.Requests;

namespace PlantTelemetryApp.Web.Controllers;

[Route("/sensors")]
public class SensorController : ControllerBase
{
    private readonly ISensorService _sensorService;
    private readonly ILogger<SensorController> _logger;
    
    public SensorController(ISensorService sensorService, ILogger<SensorController> logger)
    {
        ArgumentNullException.ThrowIfNull(sensorService);
        ArgumentNullException.ThrowIfNull(logger);
        _sensorService = sensorService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var sensors = await _sensorService.GetAllSensorsAsync();
        return Ok(sensors);
    }

    [HttpGet("{sensorId:long}")]
    public async Task<IActionResult> GetAsync(long sensorId)
    {
        var sensor = await _sensorService.GetSensorByIdAsync(sensorId);

        if (sensor is null)
        {
            return NotFound();
        }
        
        return Ok(sensor);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateSensorDto sensorDto)
    {
        var sensor = await _sensorService.CreateSensorAsync(sensorDto);
        return Ok(sensor);
    }

    [HttpDelete("{sensorId:long}")]
    public async Task<IActionResult> RemoveAsync(long sensorId)
    {
        await _sensorService.RemoveSensorAsync(sensorId);
        return NoContent();
    }
}