using Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }
        public ICollection<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
    }

    public enum ProgrammingLanguageProperties
    {
        Id,
        Name
    }

    public static class ProgrammingLanguagePropertiesExtensions
    {
        public static string GetColumnName(this ProgrammingLanguageProperties programmingLanguageProperty) => programmingLanguageProperty switch
        {
            ProgrammingLanguageProperties.Id => "Id",
            ProgrammingLanguageProperties.Name => "Name",
            _ => throw new Exception("property not found in programming language entity")
        };

        public static Expression<Func<ProgrammingLanguage, object?>> GetExpression(this ProgrammingLanguageProperties programmingLanguageProperty) => programmingLanguageProperty switch
        {
            ProgrammingLanguageProperties.Id => (x => x.Id),
            ProgrammingLanguageProperties.Name => (x => x.Name),
            _ => throw new Exception("property not found in programming language entity")
        };
    }
}
