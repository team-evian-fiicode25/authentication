using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class SessionTokenProvider : ISessionTokenProvider
{
    public ISessionToken New()
        => new SessionToken(_tokenGenerator);

    public ISessionToken FromDBO(Database.DBObjects.SessionToken sesionToken) 
        => new SessionToken(sesionToken.Token, sesionToken.Expiration);

    public Database.DBObjects.SessionToken ToDBO(ISessionToken token) => new()
    {
        Token=token.Token,
        Expiration=token.ExpiresAt
    };
        
    public SessionTokenProvider(ISecureTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}

