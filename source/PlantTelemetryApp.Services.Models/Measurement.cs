namespace PlantTelemetryApp.Services.Models;

public class Measurement
{
    public long Id { get; set; }
    
    public Metadata Metadata { get; set; } = new();
    
    public double Humidity { get; set; }
}