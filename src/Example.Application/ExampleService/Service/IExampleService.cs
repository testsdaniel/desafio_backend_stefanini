using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;

namespace Example.Application.ExampleService.Service
{
    public interface IExampleService
    {
        Task<GetAllExampleResponse> GetAllAsync();
        Task<GetByIdExampleResponse> GetByIdAsync(int id);
        Task<CreateExampleResponse> CreateAsync(CreateExampleRequest request);
        Task<UpdateExampleResponse> UpdateAsync(UpdateExampleRequest request);
        Task<DeleteExampleResponse> DeleteAsync(DeleteExampleRequest request);
    }
}
