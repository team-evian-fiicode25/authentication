namespace Fiicode25Auth.API.Types.Helper.Abstract;

public interface IPhoneNumber
{
    string Number {get;}
    bool IsVerified {get;}
    string? VerifyCode {get;}
}
