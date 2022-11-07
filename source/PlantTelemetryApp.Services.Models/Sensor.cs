namespace PlantTelemetryApp.Services.Models;

public class Sensor
{
    public long Id { get; set; }
    
    public string DeviceSerial { get; set; } = string.Empty;
    
    public string Location { get; set; } = string.Empty;
}