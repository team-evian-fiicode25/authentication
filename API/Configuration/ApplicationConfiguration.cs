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

    public Fields MandatoryFields { get 
    {
        var fields = Fields.None;

        if (_config["MandatoryFields:Username"] == "1")
            fields |= Fields.Username;

        if (_config["MandatoryFields:PhoneNumber"] == "1")
            fields |= Fields.Phone;

        if (_config["MandatoryFields:Email"] == "1")
            fields |= Fields.Email;

        return fields;
    }}

    public ApplicationConfiguration(IConfiguration config) {_config=config;}
    private IConfiguration _config;
}
