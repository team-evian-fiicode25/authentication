namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface IPhoneNumber
{
    string Number {get;}
    bool IsVerified {get;}
    string? VerifyCode {get;}
}
