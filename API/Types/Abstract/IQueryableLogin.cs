namespace Fiicode25Auth.API.Types.Abstract;

public interface IQueryableLogin
{
    string Username {get;}
    bool VerifyPassword(string password);
}
