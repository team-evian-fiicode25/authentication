using System.Globalization;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class QueryableLogin : IQueryableLogin
{
    public string Id => _loginDBObject.Id.ToString();
    public string? Username => _loginDBObject.UserName;

    public string CreatedAt => _loginDBObject.CreatedAt.ToString("o", CultureInfo.InvariantCulture);
    public string UpdatedAt => _loginDBObject.UpdatedAt.ToString("o", CultureInfo.InvariantCulture);

    public IQueryableEmail? Email {get; private set;}
    public IQueryablePhoneNumber? PhoneNumber {get; private set;}

    public bool VerifyPassword(string password)
        => _password.Verify(password);


    public QueryableLogin(Database.DBObjects.Login login,
                          IPassword password,
                          IQueryableEmail? email,
                          IQueryablePhoneNumber? phone)
    {
        _loginDBObject=login;
        _password=password;
        Email=email;
        PhoneNumber=phone;
    }

    private Database.DBObjects.Login _loginDBObject;
    private IPassword _password;
}
