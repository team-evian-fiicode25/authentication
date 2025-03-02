using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class AllLoginProviders 
{
    public ILoginProvider Login {get; private set;}
    public IPasswordProvider Password {get; private set;}
    public IEmailProvider Email {get; private set;}
    public IPhoneNumberProvider Phone {get; private set;}
    public ISessionTokenProvider SessionToken {get; private set;}
    public ISessionTokensProvider SessionTokens {get; private set;}

    public AllLoginProviders(ILoginProvider login,
                             IPasswordProvider password,
                             IEmailProvider email,
                             IPhoneNumberProvider phone,
                             ISessionTokenProvider sessionToken,
                             ISessionTokensProvider sessionTokens)
    {
        Login = login;
        Password = password;
        Email = email;
        Phone = phone;
        SessionToken = sessionToken;
        SessionTokens = sessionTokens;
    }
}

