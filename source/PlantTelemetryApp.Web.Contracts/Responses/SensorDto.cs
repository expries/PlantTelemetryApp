namespace PlantTelemetryApp.Web.Contracts.Responses;

public class SensorDto
{
    public long Id { get; set; }
    
    public string Location { get; set; } = string.Empty;

    public string DeviceSerial { get; set; } = string.Empty;
}