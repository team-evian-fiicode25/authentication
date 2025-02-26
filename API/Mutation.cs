using Fiicode25Auth.API.Types.Abstract;
using Fiicode25Auth.API.Types;
using Fiicode25Auth.Database;

namespace Fiicode25Auth.API;

public class Mutation 
{
    public IQueryableLogin CreateLogin(string username, string password)
    {
        var login = Login.FromCredentials(username, password);
        return (QueryableLogin)Provider.Database.Logins.Commit(login);
    }
}
