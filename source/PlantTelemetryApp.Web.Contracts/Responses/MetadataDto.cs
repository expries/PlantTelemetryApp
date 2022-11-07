namespace PlantTelemetryApp.Web.Contracts.Responses;

public class MetadataDto
{
    public string DeviceSerial { get; set; } = string.Empty;
    
    public DateTime Timestamp { get; set; }
}