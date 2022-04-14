using Example.Application._Common.Models.Response;
using Example.Application.CityService.Models.Dtos;
using Example.Application.CityService.Models.Request;
using Example.Application.Common;
using Example.Domain;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.CityService.Service
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly ExampleContext _db;

        public CityService(ILogger<CityService> logger, ExampleContext db) : base(logger)
            => _db = db;

        public async Task<CreateResponse> CreateAsync(CreateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newCity = new City
            {
                Name = request.Name,
                Uf = request.Uf
            };

            _db.City.Add(newCity);

            await _db.SaveChangesAsync();

            return new CreateResponse() { Id = newCity.Id };
        }

        public async Task DeleteAsync(DeleteCityRequest request)
        {
            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<GetAllResponse<CityDto>> GetAllAsync()
        {
            var entity = await _db.City.ToListAsync();
            return new GetAllResponse<CityDto>()
            {
                List = entity?.Select(a => (CityDto)a).ToList() ?? new List<CityDto>()
            };
        }

        public async Task<GetByIdResponse<CityDto>> GetByIdAsync(int id)
        {
            var response = new GetByIdResponse<CityDto>();

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Data = (CityDto)entity;

            return response;
        }

        public async Task UpdateAsync(UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Uf = request.Uf;

                await _db.SaveChangesAsync();
            }
        }
    }
}
