using Example.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Example.Infra.Data
{
    public class ExampleContext : DbContext
    {
        public DbSet<Domain.ExampleAggregate.Example> Example { get; set; }

        public DbSet<City> City { get; set; }

        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ExampleEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ExampleAggregate.Example>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.Example> orderConfiguration)
        {
            orderConfiguration.ToTable("Example", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name).IsRequired();
            orderConfiguration.Property(o => o.Age).IsRequired();
        }
    }
}
