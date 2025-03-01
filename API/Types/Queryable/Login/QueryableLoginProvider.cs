using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class QueryableLoginProvider : IQueryableLoginProvider
{
    public IQueryableLogin FromDBO(Database.DBObjects.Login login)
    {
        var l = _loginProvider.FromDBO(login);
        return new QueryableLogin(login,
            password: l.Password,
            email: l.Email != null ? new QueryableEmail(l.Email) : null,
            phone: l.PhoneNumber != null ? new QueryablePhoneNumber(l.PhoneNumber) : null);
    }

    public QueryableLoginProvider(ILoginProvider loginProvider)
    {
        _loginProvider=loginProvider;
    }
    private ILoginProvider _loginProvider;
}

