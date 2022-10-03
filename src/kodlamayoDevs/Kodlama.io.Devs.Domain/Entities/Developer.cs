using Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Developer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public AppUser AppUser { get; set; }
        public DeveloperGithub DeveloperGithub { get; set; }
    }

    public enum DeveloperProperties
    {
        Id,
        FirstName,
        LastName,
        PhoneNumber,
    }

    public static class DeveloperPropertiesExtensions
    {
        public static string GetColumnName(this DeveloperProperties developerProperty)
        {
            return developerProperty switch
            {
                DeveloperProperties.Id => "Id",
                DeveloperProperties.FirstName => "FirstName",
                DeveloperProperties.LastName => "LastName",
                DeveloperProperties.PhoneNumber => "PhoneNumber",
                _ => throw new Exception("property not found in developer entity"),
            };
        }

        public static Expression<Func<Developer, object?>> GetExpression(this DeveloperProperties developerProperty)
        {
            return developerProperty switch
            {
                DeveloperProperties.Id => (x => x.Id),
                DeveloperProperties.FirstName => (x => x.FirstName),
                DeveloperProperties.LastName => (x => x.LastName),
                DeveloperProperties.PhoneNumber => (x => x.PhoneNumber),
                _ => throw new Exception("property not found in developer entity"),
            };
        }
    }
}
