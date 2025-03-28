using Fiicode25Auth.API.Configuration.Abstract;

namespace Fiicode25Auth.API.Configuration;

public class ApplicationConfiguration : IApplicationConfiguration
{
    public Fields MandatoryFields
    {
        get
        {
            var section = _config.GetSection("MandatoryFields");

            var fields = Fields.None;

            if (section.GetValue<bool>("Username"))
                fields |= Fields.Username;

            if (section.GetValue<bool>("PhoneNumber"))
                fields |= Fields.Phone;

            if (section.GetValue<bool>("Email"))
                fields |= Fields.Email;

            return fields;
        }
    }

    public IDatabaseConfiguration DatabaseConfig
    {
        get
        {
            var section = _config.GetSection("Database");

            if (section.GetSection("InMemory").Exists())
                return new InMemoryDatabaseConfiguration();

            var mongoSection = section.GetSection("Mongo");
            if (mongoSection.Exists())
            {
                IMongoDatabaseConfiguration? result;

                if (mongoSection["Url"] != null)
                {
                    result = mongoSection.Get<MongoDatabaseConfigurationUrl>();
                }
                else
                {
                    result = mongoSection.Get<MongoDatabaseConfigurationIndividualVariables>();
                }

                if (result != null)
                    return result;

                throw new Exception("Invalid mongo configuration");
            }

            return new InMemoryDatabaseConfiguration();
        }
    }

    public IUsernameConfiguration UsernameConfig
    {
        get
        {
            var section = _config.GetSection("UsernameValidator");

            if (section.GetSection("Unconstrained").Exists())
                return new UnconstrainedUsernameConfiguration();

            var alphaNumericalSection = section.GetSection("AlphaNumerical");
            if (alphaNumericalSection.Exists())
            {
                var result = alphaNumericalSection.Get<AlphaNumericalUsernameConfiguration>();

                if (result != null)
                    return result;
                
                return new AlphaNumericalUsernameConfiguration();
            }

            return new AlphaNumericalUsernameConfiguration();
        }
    }

    public IPasswordConfiguration PasswordConfig
    {
        get
        {
            var section = _config.GetSection("Password");

            if (_config.GetSection("Insecure").Exists())
                return new InsecurePasswordConfiguration();

            if (_config.GetSection("Bcrypt").Exists())
                return new BcryptHashedPasswordConfiguration();

            return new BcryptHashedPasswordConfiguration();
        }
    }

    public ApplicationConfiguration(IConfiguration config) {_config=config;}
    private IConfiguration _config;
}
