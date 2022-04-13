using Example.Application.ExampleService.Models.Request;
using FluentValidation;

namespace Example.Application.ExampleService.Validators
{
    public class CreateExampleRequestValidator : AbstractValidator<CreateExampleRequest>
    {
        public CreateExampleRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Example name is mandatory.");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Example age must be greater than {ComparisonValue}.");
        }
    }
}
