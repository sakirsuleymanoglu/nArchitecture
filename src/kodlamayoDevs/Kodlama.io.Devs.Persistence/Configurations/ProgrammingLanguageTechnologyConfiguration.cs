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
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProgrammingLanguage).WithMany(x => x.ProgrammingLanguageTechnologies).HasForeignKey(x => x.ProgrammingLanguageId);
            builder.ToTable(Entities.ProgrammingLanguageTechnology.GetTableName());
        }
    }
}
