namespace PlantTelemetryApp.Web.Contracts.Responses;

public class MeasurementDto
{
    public MetadataDto Metadata { get; set; } = new MetadataDto();
    
    public long Humidity { get; set; }
}