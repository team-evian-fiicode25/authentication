using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.DBs.Abstract;
using Fiicode25Auth.Database.Repositories.InMemory;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.DBs;

public class InMemoryDatabase : IDatabase
{
    public ILoginRepository Logins {get; private set;} = new InMemoryLoginRepository();
}
