using Example.Application.Common;
using Example.Application.PersonService.Models.Dtos;

namespace Example.Application.PersonService.Models.Response
{
    public class GetAllPersonResponse : BaseResponse
    {
        public List<PersonDto> Persons { get; set; }
    }
}
