namespace Fiicode25Auth.API.Types.Abstract;

public interface ILogin
{
    string Username {get;}
    string PasswordHash {get;}

    string SetPassword(string password);
    bool VerifyPassword(string password);
}
