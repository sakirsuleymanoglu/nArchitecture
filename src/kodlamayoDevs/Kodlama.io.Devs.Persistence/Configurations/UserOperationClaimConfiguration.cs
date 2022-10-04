using Core.Security.Entities;
using Kodlama.io.Devs.Persistence.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(UserOperationClaimProperties.Id.GetExpression());
            builder.Property(UserOperationClaimProperties.Id.GetExpression()).HasColumnName(UserOperationClaimProperties.Id.GetColumnName());
            builder.Property(UserOperationClaimProperties.UserId.GetExpression()).HasColumnName(UserOperationClaimProperties.UserId.GetColumnName());
            builder.Property(UserOperationClaimProperties.OperationClaimId.GetExpression()).HasColumnName(UserOperationClaimProperties.OperationClaimId.GetColumnName());
            builder.ToTable(Entities.UserOperationClaim.GetTableName());
        }
    }
}
