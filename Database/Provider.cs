using Fiicode25Auth.Database.DBs;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.Database;

/// <summary>
///     Collection of relevant abstract factories used in the project
/// </summary>
public static class Provider
{
    /// <value>
    ///     An object that interfaces with the database
    /// </value>
    /// <remarks>
    ///     This SHOULD be used on a transaction level as
    ///     the implementation is responsible for managing
    ///     the lifetime of each instance
    /// </remarks>
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
    private static IDatabase? _db=null;
}
