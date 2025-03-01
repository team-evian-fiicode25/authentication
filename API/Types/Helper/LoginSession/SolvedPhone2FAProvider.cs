using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession;

public class SolvedPhone2FAProvider : IPhone2FAProvider
{
    public IPhone2FA FromCode(IPhoneNumber phone, string? code)
        => new SolvedPhone2FA(phone.Number);

    public string? GetCode(IPhone2FA phone)
        => phone.VerifyCode;

    public IPhone2FA New(IPhoneNumber phone)
    {
        if (phone.IsVerified == false)
        {
            throw new ArgumentException("Cannot make 2FA from an unverified phone number");
        }

        return new SolvedPhone2FA(phone.Number);
    }
}


