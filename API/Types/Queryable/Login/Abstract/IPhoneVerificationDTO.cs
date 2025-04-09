namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IPhoneVerificationDTO
{
    string UserId {get;}
    string? Username {get;}
    string PhoneNumber {get;}
    string VerificationCode {get;}
}
