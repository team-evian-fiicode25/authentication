using Fiicode25Auth.API.Types.Helper.Abstract;
using Fiicode25Auth.API.Types.Queryable.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Mutation 
{
    public async Task<IQueryableLogin> CreateLogin(string username,
                                                   string password,
                                                   IDatabaseProvider dbProvider,
                                                   ILoginProvider loginProvider,
                                                   IQueryableLoginProvider qLoginProvider)
    {
        var login = loginProvider.NewWithPassword(password);
        login.Username = username;

        var loginDBO = await dbProvider.Database.Logins.Commit(loginProvider.ToDBO(login));

        return qLoginProvider.FromDBO(loginDBO);
    }
}
