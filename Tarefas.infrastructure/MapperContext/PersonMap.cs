using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Domain.Entitys;

namespace Tarefas.infrastructure.MapperContext;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Identity).HasMaxLength(9).IsRequired(); //RG
        builder.Property(x => x.IndividualRegistration).HasMaxLength(11).IsRequired(); // CPF
        builder.Property(x => x.DateBirth);
    }
}
