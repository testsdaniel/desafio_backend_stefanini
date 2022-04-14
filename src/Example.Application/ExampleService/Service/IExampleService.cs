using Example.Application._Common.Models.Response;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;

namespace Example.Application.ExampleService.Service
{
    public interface IExampleService
    {
        Task<GetAllResponse<ExampleDto>> GetAllAsync();
        Task<GetByIdResponse<ExampleDto>> GetByIdAsync(int id);
        Task<CreateResponse> CreateAsync(CreateExampleRequest request);
        Task UpdateAsync(UpdateExampleRequest request);
        Task DeleteAsync(DeleteExampleRequest request);
    }
}
