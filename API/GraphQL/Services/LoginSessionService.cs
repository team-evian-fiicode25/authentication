using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL.Services;

public class LoginSessionService : ILoginSessionService
{
    public async Task<IQueryableLoginSession?> Get(string token)
    {
        var dbo = await _dbProvider.Database.LoginSessions.Get(token);
        if(dbo == null)
            return null;

        return _qLoginSessionProvider.FromDBO(dbo);
    }

    public async Task<IQueryableLoginSession> LogInWithPassword(string password,
                                                                string? id = null,
                                                                string? username = null,
                                                                string? email = null,
                                                                string? phone = null)
    {
        var loginDBO = await _loginRetriever.GetByIdentifier(id, username, phone, email);
        if (loginDBO == null)
            throw new GraphQLException("Wrong credentials");

        var login = _loginProvider.FromDBO(loginDBO);

        if (!login.Password.Verify(password))
            throw new GraphQLException("Wrong credentials");

        var loginSession = _loginSessionProvider.New(login);

        // TODO: Update interface to return LoginSessionWith2FAData instead
        var loginSessionToken
            = (await _dbProvider.Database.LoginSessions.Commit(
                    _loginSessionProvider.ToDBO(loginSession)
                )).SecureIdentifier;

        var loginSessionDBO = await _dbProvider.Database.LoginSessions.Get(loginSessionToken);

        if (loginSessionDBO == null)
            throw new Exception();

        return _qLoginSessionProvider.FromDBO(loginSessionDBO);
    }

    public LoginSessionService(IDatabaseProvider dbProvider, IQueryableLoginSessionProvider qLoginSessionProvider, ILoginRetriever loginRetriever, ILoginProvider loginProvider, ILoginSessionProvider loginSessionProvider)
    {
        _dbProvider = dbProvider;
        _qLoginSessionProvider = qLoginSessionProvider;
        _loginRetriever = loginRetriever;
        _loginProvider = loginProvider;
        _loginSessionProvider = loginSessionProvider;
    }

    private IDatabaseProvider _dbProvider;
    private IQueryableLoginSessionProvider _qLoginSessionProvider;
    private ILoginRetriever _loginRetriever;
    private ILoginProvider _loginProvider;
    private ILoginSessionProvider _loginSessionProvider;
}


