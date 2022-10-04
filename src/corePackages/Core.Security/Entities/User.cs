using Core.Persistence.Repositories;
using Core.Security.Enums;
using System.Linq.Expressions;

namespace Core.Security.Entities;

public class User : Entity
{
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
        RefreshTokens = new HashSet<RefreshToken>();
    }

    public User(int id, string email, byte[] passwordSalt, byte[] passwordHash,
                bool status, AuthenticatorType authenticatorType) : this()
    {
        Id = id;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
        AuthenticatorType = authenticatorType;
    }
}

public enum UserProperties
{
    Id,
    Email,
    PasswordSalt,
    PasswordHash,
    Status,
    AuthenticatorType
}

public static class UserPropertiesExtensions
{
    public static string GetColumnName(this UserProperties userProperty) => userProperty switch
    {
        UserProperties.Id => "Id",
        UserProperties.Email => "Email",
        UserProperties.PasswordSalt => "PasswordSalt",
        UserProperties.PasswordHash => "PasswordHash",
        UserProperties.Status => "Status",
        UserProperties.AuthenticatorType => "AuthenticatorType",
        _ => throw new Exception("property not found int user entity"),
    };

    public static Expression<Func<User, object?>> GetExpression(this UserProperties userProperty) => userProperty switch
    {
        UserProperties.Id => (x => x.Id),
        UserProperties.Email => (x => x.Email),
        UserProperties.PasswordSalt => (x => x.PasswordSalt),
        UserProperties.PasswordHash => (x => x.PasswordHash),
        UserProperties.Status => (x => x.Status),
        UserProperties.AuthenticatorType => (x => x.AuthenticatorType),
        _ => throw new Exception("property not found int user entity"),
    };
}