using Microsoft.AspNetCore.Mvc;
using PlantTelemetryApp.Services.Interfaces;
using PlantTelemetryApp.Services.Models;
using PlantTelemetryApp.Web.Contracts.Requests;

namespace PlantTelemetryApp.Web.Controllers;


[Route("/measurements")]
public class MeasurementController : ControllerBase
{
    private readonly IMeasurementService _measurementService;
    private readonly ILogger<MeasurementController> _logger;

    public MeasurementController(IMeasurementService measurementService, ILogger<MeasurementController> logger)
    {
        ArgumentNullException.ThrowIfNull(measurementService);
        ArgumentNullException.ThrowIfNull(logger);
        _measurementService = measurementService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInTimeFrameAsync([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var measurements = await _measurementService.GetAllInTimeFrameAsync(from, to);
        return Ok(measurements);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddMeasurementDto measurementDto)
    {
        var measurement = new Measurement
        {
            Humidity = measurementDto.Humidity,
            Metadata = new Metadata
            {
                Timestamp = measurementDto.Metadata.Timestamp,
                DeviceSerial = measurementDto.Metadata.DeviceSerial
            }
        };
        
        await _measurementService.AddMeasurementAsync(measurement);
        return NoContent();
    }
}