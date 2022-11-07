using FluentValidation;
using PlantTelemetryApp.Web.Contracts.Requests;

namespace PlantTelemetryApp.Web.Validators;

public class CreateSensorDtoValidator : AbstractValidator<CreateSensorDto>
{
    public CreateSensorDtoValidator()
    {
        RuleFor(x => x.Location)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.DeviceSerial)
            .NotEmpty()
            .Matches("$[a-zA-Z0-9-]*^")
            .MaximumLength(255);
    }
}