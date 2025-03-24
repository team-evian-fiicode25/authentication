using Fiicode25Auth.Database.DBs.Abstract;
using MongoDB.Driver;

namespace Fiicode25Auth.Database.DBs;

public class MongoDatabaseProvider : IDatabaseProvider
{
    public IDatabase Database
        => new MongoDatabase(new MongoClient(_dbUrl).GetDatabase(_dbName));

    public MongoDatabaseProvider(string dbUrl, string dbName)
    {
        _dbUrl = dbUrl;
        _dbName = dbName;
    }

    private string _dbUrl;
    private string _dbName;
}


