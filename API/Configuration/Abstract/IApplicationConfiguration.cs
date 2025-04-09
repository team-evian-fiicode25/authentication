namespace Fiicode25Auth.API.Configuration.Abstract;

public interface IApplicationConfiguration
{
    IDatabaseConfiguration DatabaseConfig {get;}
    ISubscriptionProviderConfiguration SubscriptionProviderConfig {get;}
    IUsernameConfiguration UsernameConfig {get;}
    IPasswordConfiguration PasswordConfig {get;}
    Fields MandatoryFields {get;}
}

[Flags]
public enum Fields
{
    None = 0,
    Username = 1,
    Email = 2,
    Phone = 4
}
