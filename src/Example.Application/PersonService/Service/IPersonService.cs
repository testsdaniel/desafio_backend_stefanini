using Example.Application.PersonService.Models.Request;
using Example.Application.PersonService.Models.Response;

namespace Example.Application.PersonService.Service
{
    public interface IPersonService
    {
        Task<GetAllPersonResponse> GetAllAsync();
        Task<GetByIdPersonResponse> GetByIdAsync(int id);
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request);
        Task<UpdatePersonResponse> UpdateAsync(UpdatePersonRequest request);
        Task<DeletePersonResponse> DeleteAsync(DeletePersonRequest request);
    }
}
