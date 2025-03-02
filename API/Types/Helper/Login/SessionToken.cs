using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class SessionToken : ISessionToken
{
    public string Token {get; private set;}

    public DateTime ExpiresAt {get; private set;}

    public DateTime Refresh()
        => ExpiresAt = DateTime.UtcNow + TimeSpan.FromHours(24);

    public SessionToken(string token, DateTime expiresAt)
    {
        if (ExpiresAt <= DateTime.UtcNow)
        {
            throw new ArgumentException("Cannot create expired session token");
        }

        Token=token;
        ExpiresAt=expiresAt;
    }

    public SessionToken(ISecureTokenGenerator tokenGenerator)
    {
        Token=tokenGenerator.Base64Url128Bytes();
        Refresh();
    }
}
