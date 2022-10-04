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
            builder.HasKey(UserProperties.Id.GetExpression());
            builder.Property(UserProperties.Id.GetExpression()).HasColumnName(UserProperties.Id.GetColumnName());
            builder.Property(UserProperties.Status.GetExpression()).HasColumnName(UserProperties.Status.GetColumnName());
            builder.Property(UserProperties.AuthenticatorType.GetExpression()).HasColumnName(UserProperties.AuthenticatorType.GetColumnName());
            builder.Property(UserProperties.Email.GetExpression()).HasColumnName(UserProperties.Email.GetColumnName());
            builder.HasIndex(UserProperties.Email.GetExpression()).IsUnique();
            builder.Property(UserProperties.PasswordHash.GetExpression()).HasColumnName(UserProperties.PasswordHash.GetColumnName());
            builder.Property(UserProperties.PasswordSalt.GetExpression()).HasColumnName(UserProperties.PasswordSalt.GetColumnName());
            builder.ToTable(Entities.User.GetTableName());
        }
    }
}
