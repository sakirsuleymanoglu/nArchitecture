using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class DeveloperGithubConfiguration : IEntityTypeConfiguration<DeveloperGithub>
    {
        public void Configure(EntityTypeBuilder<DeveloperGithub> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Url).HasColumnName("Url");
            builder.HasOne(x => x.Developer).WithOne(x => x.DeveloperGithub).HasForeignKey<DeveloperGithub>(x => x.Id);
            builder.ToTable("DeveloperGithubs");
        }
    }
}
