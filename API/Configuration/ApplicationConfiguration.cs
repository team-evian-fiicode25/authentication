using Fiicode25Auth.API.Configuration.Abstract;

namespace Fiicode25Auth.API.Configuration;

public class ApplicationConfiguration : IApplicationConfiguration
{
    public IDatabaseConfiguration DatabaseConfig { get 
    {
        var name = _config["DatabaseType"];

        if (name == "InMemory")
        {
            return new InMemoryDatabaseConfiguration();
        }

        return new InMemoryDatabaseConfiguration();
    }}


    public ApplicationConfiguration(IConfiguration config) {_config=config;}
    private IConfiguration _config;
}
