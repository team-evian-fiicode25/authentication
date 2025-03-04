using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class QueryableSessionToken : IQueryableSessionToken
{
    public string Token => _sessionToken.Token;

    public int ExpiresInSeconds
        => (int)(_sessionToken.ExpiresAt - DateTime.UtcNow).TotalSeconds;

    public Task<IQueryableLogin> Login
        => _getLogin();

    private async Task<IQueryableLogin> _getLogin()
    {
        _qLogin ??= await _loginService.Get(sessionToken: Token);

        if(_qLogin == null)
            throw new DanglingSessionTokenException();

        return _qLogin;
    }

    public QueryableSessionToken(string loginId, ISessionToken sessionToken, ILoginService loginService)
    {
        _loginId = loginId;
        _sessionToken = sessionToken;
        _loginService = loginService;
    }

    public QueryableSessionToken(IQueryableLogin login, ISessionToken sessionToken, ILoginService loginService)
    {
        _loginId = login.Id;
        _sessionToken = sessionToken;
        _loginService = loginService;
    }

    private string _loginId;
    private IQueryableLogin? _qLogin;
    private ISessionToken _sessionToken;
    private ILoginService _loginService;
}
