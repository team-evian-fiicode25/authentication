using Fiicode25Auth.API.Types.Abstract;

namespace Fiicode25Auth.API.Types;

public class QueryableLogin : IQueryableLogin
{
    public string Username => _loginDBObject.UserName;
    public bool VerifyPassword(string password)
        => new Login(_loginDBObject).VerifyPassword(password);

    private Database.DBObjects.Login _loginDBObject;

    public QueryableLogin(Database.DBObjects.Login login)
    {
        _loginDBObject=login;
    }

    public static implicit operator QueryableLogin(Database.DBObjects.Login login) 
        => new QueryableLogin(login);
}
