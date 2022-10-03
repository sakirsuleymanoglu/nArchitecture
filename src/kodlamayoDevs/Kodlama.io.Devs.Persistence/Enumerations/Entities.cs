namespace Kodlama.io.Devs.Persistence.Enumerations
{
    public enum Entities
    {
        Developer
    }

    public static class EntitiesExtesions
    {
        public static string GetTableName(this Entities entities)
        {
            return entities switch
            {
                Entities.Developer => "Developers",
                _ => throw new Exception("entity not found")
            };
        }
    }
}
