namespace Example.Application.CityService.Models.Request
{
    public class UpdateCityRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
    }
}
