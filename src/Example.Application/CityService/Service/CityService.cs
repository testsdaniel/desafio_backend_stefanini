using Example.Application.CityService.Models.Dtos;
using Example.Application.CityService.Models.Request;
using Example.Application.CityService.Models.Response;
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

        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
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

            return new CreateCityResponse() { Id = newCity.Id };
        }

        public async Task<DeleteCityResponse> DeleteAsync(int id)
        {
            var entity = await _db.Example.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCityResponse();
        }

        public async Task<GetAllCityResponse> GetAllAsync()
        {
            var entity = await _db.City.ToListAsync();
            return new GetAllCityResponse()
            {
                Cities = entity?.Select(a => (CityDto)a).ToList() ?? new List<CityDto>()
            };
        }

        public async Task<GetByIdCityResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdCityResponse();

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.City = (CityDto)entity;

            return response;
        }

        public async Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Uf = request.Uf;

                await _db.SaveChangesAsync();
            }

            return new UpdateCityResponse();
        }
    }
}
