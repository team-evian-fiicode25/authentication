namespace Fiicode25Auth.API.Types.Abstract;

public interface IQueryableLogin
{
    string Id {get;}
    string Username {get;}
    bool VerifyPassword(string password);

    string CreatedAt {get;}
    string UpdatedAt {get;}
}
