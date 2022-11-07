using PlantTelemetryApp.Web.Contracts.Responses;

namespace PlantTelemetryApp.Web.Contracts.Requests;

public class AddMeasurementDto
{
    public MetadataDto Metadata { get; set; } = new();
    
    public double Humidity { get; set; }
}