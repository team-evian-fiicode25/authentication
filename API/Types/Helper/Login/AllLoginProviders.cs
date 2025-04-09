using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Value.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class AllLoginProviders 
{
    public ILoginProvider Login {get; private set;}
    public IUsernameValueProvider UsernameValue{get; private set;}
    public IPasswordProvider Password {get; private set;}
    public IEmailProvider Email {get; private set;}
    public IPhoneNumberProvider Phone {get; private set;}
    public ISessionTokenProvider SessionToken {get; private set;}
    public ISessionTokensProvider SessionTokens {get; private set;}
    public IEmailVerificationDTOProvider EmailVerificationDTO {get; private set;}
    public IPhoneVerificationDTOProvider PhoneVerificationDTO {get; private set;}

    public AllLoginProviders(ILoginProvider login,
                             IUsernameValueProvider usernameValue,
                             IPasswordProvider password,
                             IEmailProvider email,
                             IPhoneNumberProvider phone,
                             ISessionTokenProvider sessionToken,
                             ISessionTokensProvider sessionTokens,
                             IEmailVerificationDTOProvider emailVerificationDTO,
                             IPhoneVerificationDTOProvider phoneVerificationDTO)
    {
        Login = login;
        UsernameValue = usernameValue;
        Password = password;
        Email = email;
        Phone = phone;
        SessionToken = sessionToken;
        SessionTokens = sessionTokens;
        EmailVerificationDTO = emailVerificationDTO;
        PhoneVerificationDTO = phoneVerificationDTO;
    }
}
