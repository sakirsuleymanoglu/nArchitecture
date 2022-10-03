using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(DeveloperProperties.Id.GetExpression());
            builder.Property(DeveloperProperties.Id.GetExpression()).HasColumnName(DeveloperProperties.Id.GetColumnName());

            builder.Property(DeveloperProperties.FirstName.GetExpression()).HasColumnName(DeveloperProperties.FirstName.GetColumnName());

            builder.Property(DeveloperProperties.LastName.GetExpression()).HasColumnName(DeveloperProperties.LastName.GetColumnName());

            builder.Property(DeveloperProperties.PhoneNumber.GetExpression()).HasColumnName(DeveloperProperties.PhoneNumber.GetColumnName());

            builder.HasOne(x => x.AppUser).WithOne(x => x.Developer).HasForeignKey<Developer>(x => x.Id);

            builder.ToTable(Entities.Developer.GetTableName());
        }
    }
}
