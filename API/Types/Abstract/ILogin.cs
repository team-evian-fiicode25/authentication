namespace Fiicode25Auth.API.Types.Abstract;

public interface ILogin
{
    Guid Id {get;}
    string Username {get;}
    string PasswordHash {get;}

    string SetPassword(string password);
    bool VerifyPassword(string password);
}
