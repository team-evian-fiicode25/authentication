using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.DBs.Abstract;

public interface IDatabase
{
    ILoginRepository Logins {get;}
}
