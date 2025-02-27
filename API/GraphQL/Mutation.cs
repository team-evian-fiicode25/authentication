using Fiicode25Auth.API.Types.Abstract;
using Fiicode25Auth.API.Types;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Mutation 
{
    public async Task<IQueryableLogin> CreateLogin(string username, string password, IDatabaseProvider dbProvider)
    {
        var login = Login.FromCredentials(username, password);
        return (QueryableLogin) await dbProvider.Database.Logins.Commit(login);
    }
}
