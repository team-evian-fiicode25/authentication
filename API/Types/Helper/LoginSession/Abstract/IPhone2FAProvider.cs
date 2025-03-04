using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

public interface IPhone2FAProvider
{
    IPhone2FA New(IPhoneNumber phone);

    IPhone2FA FromCode(IPhoneNumber phone, string? code);
    string? GetCode(IPhone2FA phone);
}

