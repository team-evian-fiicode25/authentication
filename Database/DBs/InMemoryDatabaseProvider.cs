using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.Database.DBs;

public class InMemoryDatabaseProvider : IDatabaseProvider
{
    private InMemoryDatabase? _database=null;
    public IDatabase Database 
        => _database ??= new InMemoryDatabase();
}
