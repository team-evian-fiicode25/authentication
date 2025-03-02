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
            loginService: _loginService,
            sessionService: _sessionService);

    public QueryableLoginSessionProvider(ILoginSessionProvider loginSessionProvider, ILoginService loginService, ISessionService sessionService)
    {
        _loginSessionProvider = loginSessionProvider;
        _loginService = loginService;
        _sessionService = sessionService;
    }

    private ILoginSessionProvider _loginSessionProvider;
    private ILoginService _loginService;
    private ISessionService _sessionService;
}

