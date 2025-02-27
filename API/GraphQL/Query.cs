using Fiicode25Auth.API.Types;
using Fiicode25Auth.API.Types.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Query
{
    public List<IQueryableLogin> Logins(IDatabaseProvider dbProvider)
    {
        return new List<IQueryableLogin>(dbProvider.Database.Logins.All().Select(l => new QueryableLogin(l)));
    }
}
