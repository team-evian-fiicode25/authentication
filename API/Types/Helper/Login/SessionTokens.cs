using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class SessionTokens : ISessionTokens
{
    protected List<ISessionToken> _sessionTokens = new();

    public IEnumerable<ISessionToken> Tokens => _sessionTokens.AsReadOnly();

    public ISessionToken Create()
    {
        _sessionTokens.Add(_provider.New());
        return _sessionTokens.Last();
    }

    public IEnumerable<ISessionToken> RemoveAll()
    {
        var tokens = new List<ISessionToken>(Tokens);
        _sessionTokens.Clear();
        return tokens;
    }

    public SessionTokens(ISessionTokenProvider provider, IEnumerable<ISessionToken>? tokens = null)
    {
        _provider = provider;

        if (tokens != null)
        {
            _sessionTokens = tokens.ToList();
        }
    }

    private ISessionTokenProvider _provider;
}
