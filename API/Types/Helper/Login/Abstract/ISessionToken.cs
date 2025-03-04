namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface ISessionToken
{
    string Token {get;}
    DateTime ExpiresAt {get;}

    DateTime Refresh();
}
