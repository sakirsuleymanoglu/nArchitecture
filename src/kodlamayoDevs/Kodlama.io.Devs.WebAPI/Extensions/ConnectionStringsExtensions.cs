using Kodlama.io.Devs.WebAPI.Enumerations;

namespace Kodlama.io.Devs.WebAPI.Extensions
{
    public static class ConnectionStringExtensions
    {
        public static string ConvertToString(this ConnectionStrings connectionStrings)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString(connectionStrings.ToString());
        }
    }
}
