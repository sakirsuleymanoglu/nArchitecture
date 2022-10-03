using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class DeveloperGithubConfiguration : IEntityTypeConfiguration<DeveloperGithub>
    {
        public void Configure(EntityTypeBuilder<DeveloperGithub> builder)
        {
            builder.HasKey(DeveloperGithubProperties.Id.GetExpression());
            builder.Property(DeveloperGithubProperties.Id.GetExpression()).HasColumnName(DeveloperGithubProperties.Id.GetColumnName());

            builder.Property(DeveloperGithubProperties.Url.GetExpression()).HasColumnName(DeveloperGithubProperties.Url.GetColumnName());

            builder.HasOne(x => x.Developer).WithOne(x => x.DeveloperGithub).HasForeignKey<DeveloperGithub>(x => x.Id);

            builder.ToTable(Entities.DeveloperGithub.GetTableName());
        }
    }
}
