using Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Core.Security.Entities;

public class OperationClaim : Entity
{
    public string Name { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name) : base(id)
    {
        Name = name;
    }
}

public enum OperationClaimProperties
{
    Id,
    Name
}

public static class OperationClaimPropertiesExtensions
{
    public static string GetColumnName(this OperationClaimProperties operationClaimProperty) => operationClaimProperty switch
    {
        OperationClaimProperties.Id => "Id",
        OperationClaimProperties.Name => "Name",
        _ => throw new Exception("property not found in operation claim entity"),
    };

    public static Expression<Func<OperationClaim, object?>> GetExpression(this OperationClaimProperties operationClaimProperty) => operationClaimProperty switch
    {
        OperationClaimProperties.Id => (x => x.Id),
        OperationClaimProperties.Name => (x => x.Name),
        _ => throw new Exception("property not found in operation claim entity"),
    };
}