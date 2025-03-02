using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.Login;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL.Services;

public class SessionService : ISessionService
{
    public async Task<IQueryableSessionToken?> MakeSessionToken(string loginId, string loginSessionToken)
    {
        var loginSessionDBO = await _dbProvider.Database.LoginSessions.Get(loginSessionToken);
        if (loginSessionDBO == null)
        {
            throw new ArgumentException("Could not find login session");
        }
        var loginSession = _loginSessionProvider.FromDBO(loginSessionDBO);

        if(!loginSession.IsSolved)
        {
            return null;
        }

        var loginDBO = await _loginRetriever.GetByIdentifier(id: loginId);

        if (loginDBO == null)
        {
            throw new ArgumentException("Could not find login");
        }

        var login = _loginProviders.Login.FromDBO(loginDBO);

        var sessionToken = login.SessionTokens.Create();

        var database = _dbProvider.Database;
        var success = (await database.LoginSessions
            .Remove(loginSessionDBO.LoginSession.Id)) != null;

        if(!success)
        {
            throw new Exception();
        }

        loginDBO = await _dbProvider.Database.Logins.Commit(
                            _loginProviders.Login.ToDBO(login));

        return _qSessionTokenProvider.FromDBO(
                    login: loginDBO,
                    sessionToken: loginDBO.SessionTokens.First(st => st.Token == sessionToken.Token)
                );
    }

    public SessionService(IDatabaseProvider dbProvider,
                          AllLoginProviders loginProviders,
                          ILoginRetriever loginRetriever,
                          IQueryableSessionTokenProvider qSessionTokenProvider,
                          ILoginSessionProvider loginSessionProvider)
    {
        _dbProvider = dbProvider;
        _loginProviders = loginProviders;
        _loginRetriever = loginRetriever;
        _qSessionTokenProvider = qSessionTokenProvider;
        _loginSessionProvider = loginSessionProvider;
    }

    private IDatabaseProvider _dbProvider;
    private AllLoginProviders _loginProviders;
    private ILoginRetriever _loginRetriever;
    private IQueryableSessionTokenProvider _qSessionTokenProvider;
    private ILoginSessionProvider _loginSessionProvider;
}


