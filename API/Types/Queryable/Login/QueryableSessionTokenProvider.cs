using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class QueryableSessionTokenProvider : IQueryableSessionTokenProvider
{
    public IQueryableSessionToken FromDBO(SessionToken sessionToken, Database.DBObjects.Login login)
    {
        if (login.SessionTokens.All(st => st.Token != sessionToken.Token))
        {
            throw new ArgumentException("Unrelated login and token provided");
        }

        return new QueryableSessionToken(
                    loginService: _loginService,
                    sessionToken: _sessionTokenProvider.FromDBO(sessionToken),
                    login: _qLoginProvider.FromDBO(login)
                );
    }

    public IQueryableSessionToken FromDBO(SessionToken sessionToken, string loginId) 
        => new QueryableSessionToken(
                    loginService: _loginService,
                    sessionToken: _sessionTokenProvider.FromDBO(sessionToken),
                    loginId: loginId
                );

    public QueryableSessionTokenProvider(IQueryableLoginProvider qLoginProvider,
                                         ILoginService loginService,
                                         ISessionTokenProvider sessionTokenProvider)
    {
        _qLoginProvider = qLoginProvider;
        _loginService = loginService;
        _sessionTokenProvider = sessionTokenProvider;
    }

    private IQueryableLoginProvider _qLoginProvider;
    private ILoginService _loginService;
    private ISessionTokenProvider _sessionTokenProvider;
}


