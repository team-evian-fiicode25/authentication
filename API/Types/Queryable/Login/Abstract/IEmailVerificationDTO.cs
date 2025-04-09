namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IEmailVerificationDTO
{
    string UserId {get;}
    string? Username {get;}
    string Email {get;}
    string VerificationToken {get;}
}
