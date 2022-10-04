using Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingLanguageTechnology : Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }

    public enum ProgrammingLanguageTechnologyProperties
    {
        Id,
        Name,
        ProgrammingLanguageId
    }

    public static class ProgrammingLanguageTechnologyPropertiesExtensions
    {
        public static Expression<Func<ProgrammingLanguageTechnology, object?>> GetExpression(this ProgrammingLanguageTechnologyProperties programmingLanguageTechnologyProperty) => programmingLanguageTechnologyProperty switch
        {
            ProgrammingLanguageTechnologyProperties.Id => (x => x.Id),
            ProgrammingLanguageTechnologyProperties.Name => (x => x.Name),
            ProgrammingLanguageTechnologyProperties.ProgrammingLanguageId => (x => x.ProgrammingLanguageId),
            _ => throw new Exception("property not found in programming language technology entity"),
        };

        public static string GetColumnName(this ProgrammingLanguageTechnologyProperties programmingLanguageTechnologyProperty) => programmingLanguageTechnologyProperty switch
        {
            ProgrammingLanguageTechnologyProperties.Id => "Id",
            ProgrammingLanguageTechnologyProperties.Name => "Name",
            ProgrammingLanguageTechnologyProperties.ProgrammingLanguageId => "ProgrammingLanguageId",
            _ => throw new Exception("property not found in programming language technology entity"),
        };
    }
}
