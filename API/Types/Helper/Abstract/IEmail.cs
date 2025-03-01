namespace Fiicode25Auth.API.Types.Helper.Abstract;

public interface IEmail
{
    string Address {get;}
    bool IsVerified {get;}

    /// <value>Verification token to be sent in email</value>
    string? VerifyToken {get;}
}
