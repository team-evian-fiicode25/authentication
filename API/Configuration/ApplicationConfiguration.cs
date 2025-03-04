using Fiicode25Auth.API.Configuration.Abstract;

namespace Fiicode25Auth.API.Configuration;

public class ApplicationConfiguration : IApplicationConfiguration
{
    public IDatabaseConfiguration DatabaseConfig { get 
    {
        var name = _config["DatabaseType"];

        if (name == "memory")
            return new InMemoryDatabaseConfiguration();

        if (name == "mongo")
        {
            return new MongoDatabaseConfiguration()
            {
                HostName = _getRequired("Mongo:HostName"),
                Port = int.Parse(_getRequired("Mongo:Port")),
                User = _getRequired("Mongo:User"),
                Password = _getRequired("Mongo:Password"),
                Database = _getRequired("Mongo:Database")
            };
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

    private string _getRequired(string query)
    {
        var conf = _config[query];
        if(conf == null)
            throw new Exception($"Missing required configuration: {query}");

        return conf;
    }
    public ApplicationConfiguration(IConfiguration config) {_config=config;}
    private IConfiguration _config;
}
