using Example.Application.CityService.Models.Request;
using Example.Infra.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Example.Application.CityService.Validators
{
    public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
    {
        private readonly ExampleContext _db;

        public CreateCityRequestValidator(ExampleContext db)
        {
            _db = db;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is mandatory.")
                .MustAsync(BeUniqueName).WithMessage("This city is already created.");

            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("City UF is mandatory.");
        }

        private async Task<bool> BeUniqueName(CreateCityRequest request, string _, CancellationToken token)
            => !await _db.City.AnyAsync(x => x.Name == request.Name && x.Uf == request.Uf, token);
    }
}
