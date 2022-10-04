using Core.Security.Entities;
using Kodlama.io.Devs.Persistence.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(OperationClaimProperties.Id.GetExpression());
            builder.Property(OperationClaimProperties.Id.GetExpression()).HasColumnName(OperationClaimProperties.Id.GetColumnName());
            builder.Property(OperationClaimProperties.Name.GetExpression()).HasColumnName(OperationClaimProperties.Name.GetColumnName());
            builder.ToTable(Entities.OperationClaim.GetTableName());
        }
    }
}
