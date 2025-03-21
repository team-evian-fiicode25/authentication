using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class Login : ILogin
{
    public Guid? Id {get; private set;}
    public string? Username {get; set;}
    public IPassword Password {get; set;}
    public IPhoneNumber? PhoneNumber {get; set;}
    public IEmail? Email {get; set;}
    public ISessionTokens SessionTokens {get; private set;}

    public Login(IPassword password, ISessionTokens sessionTokens, Guid? id = null)
    {
        Id=id;
        Password=password;
        SessionTokens=sessionTokens;
    }
}
