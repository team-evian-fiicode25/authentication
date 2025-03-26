using Fiicode25Auth.API.Configuration.Abstract;

namespace Fiicode25Auth.API.Configuration;

public class ApplicationConfiguration : IApplicationConfiguration
{
    public Fields MandatoryFields
    {
        get
        {
            var fields = Fields.None;

            if (_getOption("MandatoryFields:Username"))
                fields |= Fields.Username;

            if (_getOption("MandatoryFields:PhoneNumber"))
                fields |= Fields.Phone;

            if (_getOption("MandatoryFields:Email"))
                fields |= Fields.Email;

            return fields;
        }
    }

    public IDatabaseConfiguration DatabaseConfig { get 
    {
        var name = _config["DatabaseType"]?.ToLower();

        if (name == "memory")
            return new InMemoryDatabaseConfiguration();

        if (name == "mongo")
        {
            var url = _config["Mongo:Url"];
            if (url != null) {
                return new MongoDatabaseConfigurationUrl(url);
            }

            return new MongoDatabaseConfigurationIndividualVariables()
            {
                HostName = _getRequired("Mongo:HostName"),
                Port = _getIntRequired("Mongo:Port"),
                User = _getRequired("Mongo:User"),
                Password = _getRequired("Mongo:Password"),
                Database = _getRequired("Mongo:Database")
            };
        }

        return new InMemoryDatabaseConfiguration();
    }}

    public IUsernameConfiguration UsernameConfig
    {
        get
        {
            var name = _config["UsernameValidator"]?.ToLower();

            if (name == "unconstrained")
                return new UnconstrainedUsernameConfiguration();

            if (name == "alphanumerical")
            {
                return new AlphaNumericalUsernameConfiguration()
                {
                    MinimumLength = _getInt("AlphaNumericalUsername:MinimumLength") ?? 3,
                    MaximumLength = _getInt("AlphaNumericalUsername:MinimumLength") ?? 1 << 30,
                    AllowNumbers = _getOption("AlphaNumericalUsername:AllowNumbers"),
                    AllowUppercase = _getOption("AlphaNumericalUsername:AllowUppercase"),
                    AllowDotSeparator = _getOption("AlphaNumericalUsername:AllowDotSeparator"),
                    AllowDashSeparator = _getOption("AlphaNumericalUsername:AllowDashSeparator"),
                    AllowUnderlineSeparator = _getOption("AlphaNumericalUsername:AllowUnderlineSeparator")
                };
            }

            return new UnconstrainedUsernameConfiguration();
        }
    }

    private bool _getOption(string query)
    {
        var conf = _config[query];

        if (conf == null)
            return false;

        conf = conf.ToLower();
        if (conf == "1" || conf == "true" || conf == "yes")
            return true;

        if (conf == "0" || conf == "false" || conf == "no")
            return false;

        throw new Exception($"Wrong boolean configration received: {conf}");
    }

    private int? _getInt(string query)
    {
        var conf = _config[query];

        if (conf == null)
            return null;

        return int.Parse(conf);
    }

    private int _getIntRequired(string query)
        => int.Parse(_getRequired(query));

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
