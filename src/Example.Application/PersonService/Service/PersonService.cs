using Example.Application.Common;
using Example.Application.PersonService.Models.Dtos;
using Example.Application.PersonService.Models.Request;
using Example.Application.PersonService.Models.Response;
using Example.Domain;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.PersonService.Service
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly ExampleContext _db;

        public PersonService(ILogger<PersonService> logger, ExampleContext db) : base(logger)
            => _db = db;

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newPerson = new Person
            {
                Name = request.Name,
                Cpf = request.Cpf,
                CityId = request.CityId,
                Age = request.Age
            };

            _db.Person.Add(newPerson);
            await _db.SaveChangesAsync();

            return new CreatePersonResponse() { Id = newPerson.Id };
        }

        public async Task<DeletePersonResponse> DeleteAsync(DeletePersonRequest request)
        {
            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePersonResponse();
        }

        public async Task<GetAllPersonResponse> GetAllAsync()
        {
            var entity = await _db.Person.ToListAsync();
            return new GetAllPersonResponse()
            {
                Persons = entity?.Select(a => (PersonDto)a).ToList() ?? new List<PersonDto>()
            };
        }

        public async Task<GetByIdPersonResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdPersonResponse();

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Person = (PersonDto)entity;

            return response;
        }

        public async Task<UpdatePersonResponse> UpdateAsync(UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Cpf = request.Cpf;
                entity.CityId = request.CityId;
                entity.Age = request.Age;

                await _db.SaveChangesAsync();
            }

            return new UpdatePersonResponse();
        }
    }
}
