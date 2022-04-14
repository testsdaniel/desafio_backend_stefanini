using Example.Application._Common.Models.Response;
using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.ExampleService.Service
{
    public class ExampleService : BaseService<ExampleService>, IExampleService
    {
        private readonly ExampleContext _db;

        public ExampleService(ILogger<ExampleService> logger, ExampleContext db) : base(logger)
            => _db = db;

        public async Task<GetAllResponse<ExampleDto>> GetAllAsync()
        {
            var entity = await _db.Example.ToListAsync();
            return new GetAllResponse<ExampleDto>()
            {
                List = entity?.Select(a => (ExampleDto)a).ToList() ?? new List<ExampleDto>()
            };
        }

        public async Task<GetByIdResponse<ExampleDto>> GetByIdAsync(int id)
        {

            var response = new GetByIdResponse<ExampleDto>();

            var entity = await _db.Example.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Data = (ExampleDto)entity;

            return response;
        }

        public async Task<CreateResponse> CreateAsync(CreateExampleRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newExample = new Domain.Example()
            {
                Name = request.Name,
                Age = request.Age
            };

            _db.Example.Add(newExample);

            await _db.SaveChangesAsync();

            return new CreateResponse() { Id = newExample.Id };
        }

        public async Task UpdateAsync(UpdateExampleRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Example.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Age = request.Age;
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(DeleteExampleRequest request)
        {
            var entity = await _db.Example.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
