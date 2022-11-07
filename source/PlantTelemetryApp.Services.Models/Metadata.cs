namespace PlantTelemetryApp.Services.Models;

public class Metadata
{
    public long Id { get; set; }
    
    public string DeviceSerial { get; set; } = string.Empty;
    
    public DateTime Timestamp { get; set; }
}