using Example.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Example.Infra.Data
{
    public class ExampleContext : DbContext
    {
        public DbSet<Domain.Example> Example { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Person> Person { get; set; }

        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
