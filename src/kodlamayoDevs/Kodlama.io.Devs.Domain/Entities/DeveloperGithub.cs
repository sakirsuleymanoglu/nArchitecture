using Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class DeveloperGithub : Entity
    {
        public string Url { get; set; }
        public Developer Developer { get; set; }
    }

    public enum DeveloperGithubProperties
    {
        Id,
        Url,
    }

    public static class DeveloperGithubPropertiesExtensions
    {
        public static string GetColumnName(this DeveloperGithubProperties developerGithubProperty) => developerGithubProperty switch
        {
            DeveloperGithubProperties.Id => "Id",
            DeveloperGithubProperties.Url => "Url",
            _ => throw new Exception("property not found in developer github entity"),
        };

        public static Expression<Func<DeveloperGithub, object?>> GetExpression(this DeveloperGithubProperties developerGithubProperty) => developerGithubProperty switch
        {
            DeveloperGithubProperties.Id => (x => x.Id),
            DeveloperGithubProperties.Url => (x => x.Url),
            _ => throw new Exception("property not found in developer github entity"),
        };
    }
}
