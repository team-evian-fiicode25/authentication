using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Query
{
    public List<IQueryableLogin> Logins(IDatabaseProvider dbProvider, IQueryableLoginProvider qLoginProvider)
    {
        return new List<IQueryableLogin>(dbProvider.Database.Logins.All().Select(l => qLoginProvider.FromDBO(l)));
    }

    public async Task<IQueryableLogin?> GetLogin(string username,
                                    IDatabaseProvider dbProvider,
                                    IQueryableLoginProvider qLoginProvider)
    {
        var dbo = await dbProvider.Database.Logins.ByUsername(username);
        if (dbo == null)
            return null;

        return qLoginProvider.FromDBO(dbo.Value);
    }
}
