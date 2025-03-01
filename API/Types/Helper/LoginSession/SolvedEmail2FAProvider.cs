using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession;

public class SolvedEmail2FAProvider : IEmail2FAProvider
{
    public IEmail2FA FromCode(IEmail email, string? code)
        => new SolvedEmail2FA(email.Address);


    public string? GetCode(IEmail2FA email)
        => email.VerifyCode;

    public IEmail2FA New(IEmail email)
    {
        if(!email.IsVerified)
            throw new ArgumentException("Cannot make 2FA from an unverified email");

        return new SolvedEmail2FA(email.Address);
    }
}


