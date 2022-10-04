using Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Core.Security.Entities;

public class UserOperationClaim : Entity
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int id, int userId, int operationClaimId) : base(id)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}

public enum UserOperationClaimProperties
{
    Id,
    UserId,
    OperationClaimId,
}

public static class UserOperationClaimPropertiesExtensions
{
    public static string GetColumnName(this UserOperationClaimProperties userOperationClaimProperty) => userOperationClaimProperty switch
    {
        UserOperationClaimProperties.Id => "Id",
        UserOperationClaimProperties.UserId => "UserId",
        UserOperationClaimProperties.OperationClaimId => "OperationClaimId",
        _ => throw new Exception("property not found in user operation claim entity"),
    };

    public static Expression<Func<UserOperationClaim, object?>> GetExpression(this UserOperationClaimProperties userOperationClaimProperty) => userOperationClaimProperty switch
    {
        UserOperationClaimProperties.Id => (x => x.Id),
        UserOperationClaimProperties.UserId => (x => x.UserId),
        UserOperationClaimProperties.OperationClaimId => (x => x.OperationClaimId),
        _ => throw new Exception("property not found in user operation claim entity"),
    };
}