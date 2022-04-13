namespace Example.Application.PersonService.Models.Request
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
    }
}
