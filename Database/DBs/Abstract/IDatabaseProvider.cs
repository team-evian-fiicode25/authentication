namespace Fiicode25Auth.Database.DBs.Abstract;

public interface IDatabaseProvider 
{
    /// <value>
    ///     An object that interfaces with the database
    /// </value>
    /// <remarks>
    ///     This SHOULD be used on a transaction level as
    ///     the implementation is responsible for managing
    ///     the lifetime of each instance
    /// </remarks>
    IDatabase Database {get;}
}
