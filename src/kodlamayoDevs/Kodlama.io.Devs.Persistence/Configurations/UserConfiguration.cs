using Core.Security.Entities;
using Kodlama.io.Devs.Persistence.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.AuthenticatorType).HasColumnName("AuthenticatorType");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
            builder.ToTable(Entities.User.GetTableName());
        }
    }
}
