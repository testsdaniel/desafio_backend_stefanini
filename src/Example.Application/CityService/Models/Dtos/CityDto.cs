using Example.Domain;

namespace Example.Application.CityService.Models.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }

        public static explicit operator CityDto(City city)
        {
            return new CityDto()
            {
                Id = city.Id,
                Name = city.Name,
                Uf = city.Uf
            };
        }
    }
}
