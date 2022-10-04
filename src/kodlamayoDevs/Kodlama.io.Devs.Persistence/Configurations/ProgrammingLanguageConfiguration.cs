using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.HasKey(ProgrammingLanguageProperties.Id.GetExpression());
            builder.Property(ProgrammingLanguageProperties.Id.GetExpression()).HasColumnName(ProgrammingLanguageProperties.Id.GetColumnName());

            builder.Property(ProgrammingLanguageProperties.Name.GetExpression()).HasColumnName(ProgrammingLanguageProperties.Name.GetColumnName());
            builder.HasIndex(ProgrammingLanguageProperties.Name.GetExpression()).IsUnique();

            builder.ToTable(Entities.ProgrammingLanguage.GetTableName());
        }
    }
}
