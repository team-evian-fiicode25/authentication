using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.DBs.Abstract;

/// <summary>
///     Collection of related repositories <br />
///     Ment to represent a full databaase solution
/// </summary>
public interface IDatabase
{
    ILoginRepository Logins {get;}
    ILoginSessionRepository LoginSessions {get;}
}
