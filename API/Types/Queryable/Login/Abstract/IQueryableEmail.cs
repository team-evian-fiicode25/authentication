namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IQueryableEmail
{
    string Address {get;}
    bool IsVerified {get;}
    string? VerifyToken {get;}
}

