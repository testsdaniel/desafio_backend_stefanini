using Example.Application.CityService.Models.Request;
using Example.Infra.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Example.Application.CityService.Validators
{
    public class DeleteCityRequestValidator : AbstractValidator<DeleteCityRequest>
    {
        private readonly ExampleContext _db;

        public DeleteCityRequestValidator(ExampleContext db)
        {
            _db = db;

            RuleFor(x => x.Id)
                .MustAsync(NotBeLinkedToPerson).WithMessage("Can't be deleted because is linked to person(s).");
        }

        private async Task<bool> NotBeLinkedToPerson(DeleteCityRequest request, int _, CancellationToken token)
            => !await _db.Person.AnyAsync(x => x.CityId == request.Id, token);
    }
}
