using FluentValidation;
using PlantTelemetryApp.Web.Contracts.Requests;

namespace PlantTelemetryApp.Web.Validators;

public class AddMeasurementDtoValidator : AbstractValidator<AddMeasurementDto>
{
    public AddMeasurementDtoValidator()
    {
        RuleFor(x => x.Metadata.Timestamp)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now.AddSeconds(1));

        RuleFor(x => x.Humidity)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(100);
    }
}