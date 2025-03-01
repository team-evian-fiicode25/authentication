using System.Globalization;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.LoginSession;

public class QueryableLoginSession : IQueryableLoginSession
{
    public string Id => _loginSessionDBO.Id.ToString();
    public string LoginId => _loginSession.LoginId.ToString();
    public string IdentifyingToken => _loginSession.IdentifyingToken;

    public bool IsSolved => _loginSession.IsSolved;

    public string CreatedAt => _loginSessionDBO.CreatedAt.ToString("o", CultureInfo.InvariantCulture);
    public string UpdatedAt => _loginSessionDBO.UpdatedAt.ToString("o", CultureInfo.InvariantCulture);

    public int TimeLeftSeconds => (int)(_loginSession.ExpiresAt - DateTime.UtcNow).TotalSeconds;

    
    public List<TwoFactorMean> Solved2FAOptions { get {
        var options = new List<TwoFactorMean>();

        if(_loginSession.Email != null && _loginSession.Email.IsSolved)
            options.Add(TwoFactorMean.Email);

        if(_loginSession.Phone != null && _loginSession.Phone.IsSolved)
            options.Add(TwoFactorMean.Phone);

        return options;
    }}
    public List<TwoFactorMean> Available2FAOptions { get {
        var options = new List<TwoFactorMean>();

        if(_loginSession.Email != null)
            options.Add(TwoFactorMean.Email);

        if(_loginSession.Phone != null)
            options.Add(TwoFactorMean.Phone);

        return options.Except(Solved2FAOptions).ToList();
    }}

    public Task<IQueryableLogin> Login => _getLogin();
    private async Task<IQueryableLogin> _getLogin()
    {
        var loginDBO = await _databaseProvider.Database.Logins.ById(_loginSession.LoginId);

        if(loginDBO == null)
            throw new DanglingLoginSessionException();

        return _qLoginProvider.FromDBO(loginDBO);
    }


    public QueryableLoginSession(ILoginSession loginSession,
                                 Database.DBObjects.LoginSession loginSessionDBO,
                                 IDatabaseProvider databaseProvider,
                                 IQueryableLoginProvider qLoginProvider)
    {
        _loginSession = loginSession;
        _loginSessionDBO = loginSessionDBO;
        _databaseProvider = databaseProvider;
        _qLoginProvider = qLoginProvider;
    }

    private ILoginSession _loginSession;
    private Database.DBObjects.LoginSession _loginSessionDBO;
    private IDatabaseProvider _databaseProvider;
    private IQueryableLoginProvider _qLoginProvider;
}
