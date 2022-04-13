using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infra.Data.Configs
{
    class ExampleConfig : IEntityTypeConfiguration<Domain.Example>
    {
        public void Configure(EntityTypeBuilder<Domain.Example> builder)
        {
            builder.ToTable("Example");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Age).IsRequired();
        }
    }
}
