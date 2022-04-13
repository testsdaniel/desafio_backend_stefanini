using Example.Application.Common;
using Example.Application.PersonService.Models.Dtos;

namespace Example.Application.PersonService.Models.Response
{
    public class GetByIdPersonResponse : BaseResponse
    {
        public PersonDto Person { get; set; }
    }
}
