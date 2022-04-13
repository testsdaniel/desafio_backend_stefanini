using Example.Application.PersonService.Models.Request;
using Example.Infra.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Example.Application.PersonService.Validators
{
    public class UpdatePersonRequestValidator : AbstractValidator<UpdatePersonRequest>
    {
        private readonly ExampleContext _db;

        public UpdatePersonRequestValidator(ExampleContext db)
        {
            _db = db;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The person name is mandatory.")
                .MaximumLength(300).WithMessage("The person name has a maximun length of {MaxLength} characters.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("The person CPF is mandatory.")
                .MaximumLength(11).WithMessage("The person CPF has a maximun length of {MaxLength} characters.")
                .MustAsync(BeUniqueCpf).WithMessage("This person CPF is already created.");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("The person age is mandatory.");

            RuleFor(x => x.CityId)
                .MustAsync(BeValidCity).WithMessage("The person city must be a valid city.");
        }

        private async Task<bool> BeUniqueCpf(UpdatePersonRequest request, string _, CancellationToken token)
            => !await _db.Person.AnyAsync(x => x.Cpf == request.Cpf && x.Id != request.Id, token);

        private async Task<bool> BeValidCity(UpdatePersonRequest request, int _, CancellationToken token)
            => await _db.City.AnyAsync(x => x.Id == request.CityId, token);
    }
}
