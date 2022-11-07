namespace PlantTelemetryApp.Services.Exceptions;

public class ServiceException : Exception
{
    public ServiceException()
    {
    }

    public ServiceException(string msg) : base(msg)
    {
        
    }

    public ServiceException(string msg, Exception inner) : base(msg, inner)
    {
        
    }
}