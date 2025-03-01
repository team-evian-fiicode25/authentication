using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;
using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.LoginSession;

public class QueryableLoginSessionProvider : IQueryableLoginSessionProvider
{
    public IQueryableLoginSession FromDBO(LoginSessionWith2FAData loginSession)
        => new QueryableLoginSession(
            loginSessionDBO: loginSession.LoginSession,
            loginSession: _loginSessionProvider.FromDBO(loginSession),
            databaseProvider: _dbProvider,
            qLoginProvider: _qLoginProvider);

    public QueryableLoginSessionProvider(IDatabaseProvider dbProvider,
                                         IQueryableLoginProvider qLoginProvider,
                                         ILoginProvider loginProvider,
                                         ILoginSessionProvider loginSessionProvider)
    {
        _dbProvider = dbProvider;
        _qLoginProvider = qLoginProvider;
        _loginProvider = loginProvider;
        _loginSessionProvider = loginSessionProvider;
    }

    private IDatabaseProvider _dbProvider;
    private IQueryableLoginProvider _qLoginProvider;
    private ILoginProvider _loginProvider;
    private ILoginSessionProvider _loginSessionProvider;
}

