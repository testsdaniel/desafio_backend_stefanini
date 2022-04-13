using Example.Application.ExampleService.Models.Response;
using FluentValidation;

namespace Example.Application.ExampleService.Validators
{
    public class UpdateExampleRequestValidator : AbstractValidator<UpdateExampleRequest>
    {
        public UpdateExampleRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Example name is mandatory");

            RuleFor(x => x.Age)
                .GreaterThan(50).WithMessage("Example age must be greater than {ComparisonValue}.");
        }
    }
}
