namespace Fiicode25Auth.API.Configuration.Abstract;

public interface ISubscriptionProviderConfiguration { }

public class InMemorySubscriptionProviderConfiguration : ISubscriptionProviderConfiguration { }

public class RedisSubscriptionProviderConfiguration : ISubscriptionProviderConfiguration
{
    public required string Host { get; set; }
    public required int Port { get; set; }
}
