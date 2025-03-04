namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface ISessionTokens
{
    IEnumerable<ISessionToken> Tokens {get;}

    ISessionToken Create();
    IEnumerable<ISessionToken> RemoveAll();
}
