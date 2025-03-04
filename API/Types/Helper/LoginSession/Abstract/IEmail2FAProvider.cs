using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

public interface IEmail2FAProvider
{
    IEmail2FA New(IEmail email);

    IEmail2FA FromCode(IEmail email, string? code);
    string? GetCode(IEmail2FA email);
}

