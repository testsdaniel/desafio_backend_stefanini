using Example.Application._Common.Models.Response;
using Example.Application.CityService.Models.Dtos;
using Example.Application.CityService.Models.Request;

namespace Example.Application.CityService.Service
{
    public interface ICityService
    {
        Task<GetAllResponse<CityDto>> GetAllAsync();
        Task<GetByIdResponse<CityDto>> GetByIdAsync(int id);
        Task<CreateResponse> CreateAsync(CreateCityRequest request);
        Task UpdateAsync(UpdateCityRequest request);
        Task DeleteAsync(DeleteCityRequest request);
    }
}
