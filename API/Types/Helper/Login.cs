using Fiicode25Auth.API.Types.Helper.Abstract;

namespace Fiicode25Auth.API.Types.Helper;

public class Login : ILogin
{
    public Guid? Id {get; private set;}
    public string? Username {get; set;}
    public IPassword Password {get; set;}
    public IPhoneNumber? PhoneNumber {get; set;}
    public IEmail? Email {get; set;}

    public Login(IPassword password)
    {
        Password=password;
    }
}
