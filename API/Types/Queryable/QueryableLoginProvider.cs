using Fiicode25Auth.API.Types.Helper.Abstract;
using Fiicode25Auth.API.Types.Queryable.Abstract;
using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.API.Types.Queryable;

public class QueryableLoginProvider : IQueryableLoginProvider
{
    public IQueryableLogin FromDBO(Login login)
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

