namespace Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

public interface ILoginSession
{
    Guid? Id {get;}
    string IdentifyingToken {get;}

    DateTime ExpiresAt {get;}

    IEmail2FA? Email {get;}
    IPhone2FA? Phone {get;}

    Guid LoginId {get;}

    bool IsSolved {get;}
}

