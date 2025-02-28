using Fiicode25Auth.API.Types.Helper.Abstract;

namespace Fiicode25Auth.API.Types.Helper;

public class AllLoginProviders 
{
    public ILoginProvider Login {get; private set;}
    public IPasswordProvider Password {get; private set;}
    public IEmailProvider Email {get; private set;}
    public IPhoneNumberProvider Phone {get; private set;}

    public AllLoginProviders(ILoginProvider login,
                             IPasswordProvider password,
                             IEmailProvider email,
                             IPhoneNumberProvider phone)
    {
        Login = login;
        Password = password;
        Email = email;
        Phone = phone;
    }
}

