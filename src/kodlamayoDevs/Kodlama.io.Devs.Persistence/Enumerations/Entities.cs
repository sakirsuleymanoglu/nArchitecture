namespace Kodlama.io.Devs.Persistence.Enumerations
{
    public enum Entities
    {
        Developer,
        DeveloperGithub,
        ProgrammingLanguage,
        ProgrammingLanguageTechnology,
        OperationClaim,
        User,
        UserOperationClaim,
        RefreshToken
    }

    public static class EntitiesExtesions
    {
        public static string GetTableName(this Entities entities) => entities switch
        {
            Entities.Developer => "Developers",
            Entities.DeveloperGithub => "DeveloperGithubs",
            Entities.ProgrammingLanguage => "ProgrammingLanguages",
            Entities.ProgrammingLanguageTechnology => "ProgrammingLanguageTechnologies",
            Entities.User => "Users",
            Entities.OperationClaim => "OperationClaims",
            Entities.UserOperationClaim => "UserOperationClaims",
            Entities.RefreshToken => "RefreshTokens",
            _ => throw new Exception("entity not found")
        };
    }
}
