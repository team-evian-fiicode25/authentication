using Fiicode25Auth.API.Types.Abstract;

namespace Fiicode25Auth.API.Types;

public class Login : ILogin
{

    public string Username {get; private set;}
    public string PasswordHash {get; private set;}

    public string SetPassword(string password)
    {
        return PasswordHash=BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }

    public Login(Database.DBObjects.Login login)
    {
        Username=login.UserName;
        PasswordHash=login.PasswordHash;
    }

    private Login(string username, string password)
    {
        Username=username;
        PasswordHash=""; // Suppress CS8618 warning
        SetPassword(password);
    }

    public static Login FromCredentials(string username, string password)
        => new Login(username, password);

    public static implicit operator Login(Database.DBObjects.Login login) => new Login(login);
    public static implicit operator Database.DBObjects.Login(Login login) 
        => new Database.DBObjects.Login()
             {
                 UserName=login.Username,
                 PasswordHash=login.PasswordHash
             };
}
