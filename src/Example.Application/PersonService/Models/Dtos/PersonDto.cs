using Example.Domain;

namespace Example.Application.PersonService.Models.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }

        public static explicit operator PersonDto(Person person)
        {
            return new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Cpf = person.Cpf,
                CityId = person.CityId,
                Age = person.Age
            };
        }
    }
}
