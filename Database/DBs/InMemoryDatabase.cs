using Fiicode25Auth.Database.DBs.Abstract;
using Fiicode25Auth.Database.Repositories.InMemory;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.DBs;

/// <summary>
///     Mock database implementation using <c>List<T></c>
/// </summary>
public class InMemoryDatabase : IDatabase
{
    public ILoginRepository Logins {get; private set;} = new InMemoryLoginRepository();
}
