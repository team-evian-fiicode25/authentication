using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;
using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.API.Types.Queryable.LoginSession;

public class QueryableLoginSessionProvider : IQueryableLoginSessionProvider
{
    public IQueryableLoginSession FromDBO(LoginSessionWith2FAData loginSession)
        => new QueryableLoginSession(
            loginSessionDBO: loginSession.LoginSession,
            loginSession: _loginSessionProvider.FromDBO(loginSession), 
            loginService: _loginService
            );

    public QueryableLoginSessionProvider(ILoginSessionProvider loginSessionProvider, ILoginService loginService)
    {
        _loginSessionProvider = loginSessionProvider;
        _loginService = loginService;
    }

    private ILoginSessionProvider _loginSessionProvider;
    private ILoginService _loginService;
}

