using Example.Application._Common.Models.Response;
using Example.Application.PersonService.Models.Dtos;
using Example.Application.PersonService.Models.Request;

namespace Example.Application.PersonService.Service
{
    public interface IPersonService
    {
        Task<GetAllResponse<PersonDto>> GetAllAsync();
        Task<GetByIdResponse<PersonDto>> GetByIdAsync(int id);
        Task<CreateResponse> CreateAsync(CreatePersonRequest request);
        Task UpdateAsync(UpdatePersonRequest request);
        Task DeleteAsync(DeletePersonRequest request);
    }
}
