namespace Example.Application.PersonService.Models.Request
{
    public class UpdatePersonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
    }
}
