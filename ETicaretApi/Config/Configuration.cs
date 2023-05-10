namespace ETicaretApi.Config
{
    public class Configuration
    {
        public static string ConnectionString
        {

            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../ETicaretApi"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("PostgreSQL");
            }

        }
    }
}

