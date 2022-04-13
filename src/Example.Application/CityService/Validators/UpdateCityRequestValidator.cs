using Example.Application.CityService.Models.Request;
using Example.Infra.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Example.Application.CityService.Validators
{
    public class UpdateCityRequestValidator : AbstractValidator<UpdateCityRequest>
    {
        private readonly ExampleContext _db;

        public UpdateCityRequestValidator(ExampleContext db)
        {
            _db = db;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is mandatory.")
                .MaximumLength(200).WithMessage("City name has a maximun length of {MaxLength}.")
                .MustAsync(BeUniqueName).WithMessage("This city is already created.");

            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("City UF is mandatory.")
                .MaximumLength(2).WithMessage("City UF has a maximun length of {MaxLength}.");
        }

        private async Task<bool> BeUniqueName(UpdateCityRequest request, string _, CancellationToken token)
            => !await _db.City.AnyAsync(x => x.Name == request.Name && x.Uf == request.Uf && x.Id != request.Id, token);
    }
}
