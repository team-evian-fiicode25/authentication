namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IQueryableSessionToken
{
    string Token {get;}
    int ExpiresInSeconds {get;}
    Task<IQueryableLogin> Login {get;}
}
