namespace Fiicode25Auth.API.Configuration.Abstract;

public interface IDatabaseConfiguration
{}

public class InMemoryDatabaseConfiguration : IDatabaseConfiguration
{}

public class MongoDatabaseConfiguration : IDatabaseConfiguration
{
    public required string HostName {get; set;}
    public required int Port {get; set;}
    public required string User {get; set;}
    public required string Password {get; set;}
    public required string Database {get; set;}

    public string url => $"mongodb://{User}:{Password}@{HostName}:{Port}";
}
