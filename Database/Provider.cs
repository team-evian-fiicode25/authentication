using Fiicode25Auth.Database.DBs;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.Database;

public static class Provider
{
    private static IDatabase? _db=null;
    public static IDatabase Database 
    {
        get
        {
            if(_db != null)
            {
                return _db;
            }
        
            return _db = new InMemoryDatabase();
        }
    } 
}
