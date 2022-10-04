using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class ProgrammingLanguageTechnologyConfiguration : IEntityTypeConfiguration<ProgrammingLanguageTechnology>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguageTechnology> builder)
        {
            builder.HasKey(ProgrammingLanguageTechnologyProperties.Id.GetExpression());

            builder.Property(ProgrammingLanguageTechnologyProperties.Id.GetExpression()).HasColumnName(ProgrammingLanguageTechnologyProperties.Id.GetColumnName());

            builder.Property(ProgrammingLanguageTechnologyProperties.Name.GetExpression()).HasColumnName(ProgrammingLanguageTechnologyProperties.Name.GetColumnName());

            builder.Property(ProgrammingLanguageTechnologyProperties.ProgrammingLanguageId.GetExpression()).HasColumnName(ProgrammingLanguageTechnologyProperties.ProgrammingLanguageId.GetColumnName());

            builder.HasOne(x => x.ProgrammingLanguage).WithMany(x => x.ProgrammingLanguageTechnologies).HasForeignKey(x => x.ProgrammingLanguageId);

            builder.ToTable(Entities.ProgrammingLanguageTechnology.GetTableName());
        }
    }
}
