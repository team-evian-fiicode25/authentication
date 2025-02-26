using Fiicode25Auth.API.Types.Abstract;
using Fiicode25Auth.API.Types;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API;

public class Mutation 
{
    public IQueryableLogin CreateLogin(string username, string password, IDatabaseProvider dbProvider)
    {
        var login = Login.FromCredentials(username, password);
        return (QueryableLogin)dbProvider.Database.Logins.Commit(login);
    }
}
