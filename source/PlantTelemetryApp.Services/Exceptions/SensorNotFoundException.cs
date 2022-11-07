namespace PlantTelemetryApp.Services.Exceptions;

public class SensorNotFoundException : ServiceException
{
    public SensorNotFoundException()
    {
    }

    public SensorNotFoundException(string msg) : base(msg)
    {
        
    }

    public SensorNotFoundException(string msg, Exception inner) : base(msg, inner)
    {
        
    }
}