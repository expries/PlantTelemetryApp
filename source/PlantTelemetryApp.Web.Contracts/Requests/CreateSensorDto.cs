namespace PlantTelemetryApp.Web.Contracts.Requests;

public class CreateSensorDto
{
    public string DeviceSerial { get; set; } = string.Empty;
    
    public string Location { get; set; } = string.Empty;
}