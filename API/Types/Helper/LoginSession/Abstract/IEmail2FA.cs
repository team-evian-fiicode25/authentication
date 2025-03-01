namespace Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

public interface IEmail2FA : ISolvable
{
    string Address {get;}
    string? VerifyCode {get;}

    string RequestCode();
    bool Verify(string code);
}

