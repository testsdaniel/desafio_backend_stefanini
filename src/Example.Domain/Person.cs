namespace Example.Domain
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cpf { get; set; }

        public int CityId { get; set; }

        public int Age { get; set; }

        public virtual City City { get; set; }
    }
}
