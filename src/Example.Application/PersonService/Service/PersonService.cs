using Example.Application._Common.Models.Response;
using Example.Application.Common;
using Example.Application.PersonService.Models.Dtos;
using Example.Application.PersonService.Models.Request;
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

        public async Task<CreateResponse> CreateAsync(CreatePersonRequest request)
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

            return new CreateResponse() { Id = newPerson.Id };
        }

        public async Task DeleteAsync(DeletePersonRequest request)
        {
            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<GetAllResponse<PersonDto>> GetAllAsync()
        {
            var entity = await _db.Person.ToListAsync();
            return new GetAllResponse<PersonDto>()
            {
                List = entity?.Select(a => (PersonDto)a).ToList() ?? new List<PersonDto>()
            };
        }

        public async Task<GetByIdResponse<PersonDto>> GetByIdAsync(int id)
        {
            var response = new GetByIdResponse<PersonDto>();

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Data = (PersonDto)entity;

            return response;
        }

        public async Task UpdateAsync(UpdatePersonRequest request)
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
        }
    }
}
