namespace PlantTelemetryApp.Web.Contracts.Responses;

public class ErrorDto
{
    public ErrorCodeDto Code { get; set; }
    
    public string Field { get; set; } = string.Empty;
}