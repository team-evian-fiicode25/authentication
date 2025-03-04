using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class SessionTokensProvider : ISessionTokensProvider
{
    public ISessionTokens New()
        => new SessionTokens(_provider);

    public ISessionTokens FromDBO(List<Database.DBObjects.SessionToken> sessionTokens)
    {
        var asHelper = sessionTokens.Select(st => _provider.FromDBO(st));

        return new SessionTokens(tokens: asHelper, provider: _provider);
    }


    public List<Database.DBObjects.SessionToken> ToDBO(ISessionTokens sessionTokens)
        => sessionTokens.Tokens
            .Select(st => _provider.ToDBO(st))
            .ToList();

    public SessionTokensProvider(ISessionTokenProvider provider)
    {
        _provider = provider;
    }

    private ISessionTokenProvider _provider;
}

