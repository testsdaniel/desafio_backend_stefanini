using Example.Application.CityService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CityService.Models.Response
{
    public class GetByIdCityResponse : BaseResponse
    {
        public CityDto City { get; set; }
    }
}
