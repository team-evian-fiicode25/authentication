using System.Globalization;
using Fiicode25Auth.API.Types.Abstract;

namespace Fiicode25Auth.API.Types;

public class QueryableLogin : IQueryableLogin
{
    public string Id => _loginDBObject.Id.ToString();
    public string Username => _loginDBObject.UserName;

    public bool VerifyPassword(string password)
        => new Login(_loginDBObject).VerifyPassword(password);

    public string CreatedAt => _loginDBObject.CreatedAt.ToString("o", CultureInfo.InvariantCulture);
    public string UpdatedAt => _loginDBObject.UpdatedAt.ToString("o", CultureInfo.InvariantCulture);

    private Database.DBObjects.Login _loginDBObject;

    public QueryableLogin(Database.DBObjects.Login login)
    {
        _loginDBObject=login;
    }

    public static implicit operator QueryableLogin(Database.DBObjects.Login login) 
        => new QueryableLogin(login);
}
