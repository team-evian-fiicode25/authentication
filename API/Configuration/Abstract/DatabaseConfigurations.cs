using System.Text.RegularExpressions;

namespace Fiicode25Auth.API.Configuration.Abstract;

public interface IDatabaseConfiguration
{}

public class InMemoryDatabaseConfiguration : IDatabaseConfiguration
{}

public interface IMongoDatabaseConfiguration : IDatabaseConfiguration
{
    string Url {get;}
    string Database {get;}
}

public class MongoDatabaseConfigurationUrl : IMongoDatabaseConfiguration
{
    private string? _url;
    public string Url
    {
        get => _url ?? "";
        set
        {

            var prefixRemoved = Regex.Replace(value, @".*:\/\/", "");

            var match = Regex.Match(prefixRemoved, @"(?<=\/)[a-zA-z0-9_]+");

            if (!match.Success)
            {
                _url = value;
                return;
            }

            _database = match.Value;

            if (value.Contains('?'))
            {
                _url = Regex.Replace(value, @"(?<=\/)[a-zA-z0-9_]+(?=\?)", "");
            }
            else
            {
                _url = Regex.Replace(value, @"(?<=\/)[a-zA-z0-9_]+$", "");
            }
        }
    }

    private string? _database;
    public string Database => _database ?? "authentication";
}

public class MongoDatabaseConfigurationIndividualVariables : IMongoDatabaseConfiguration
{
    public required string HostName {get; set;}
    public required int Port {get; set;} = 27017;
    public required string User {get; set;} = "admin";
    public required string Password {get; set;}
    public required string Database {get; set;} = "authentication";

    public string Url => $"mongodb://{User}:{Password}@{HostName}:{Port}";
}
