namespace Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

public interface IPhone2FA : ISolvable
{
    string Number {get;}
    string? VerifyCode {get;}

    string RequestCode();
    bool Verify(string code);
}

