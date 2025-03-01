using Fiicode25Auth.API.Types.Queryable.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Query
{
    public List<IQueryableLogin> Logins(IDatabaseProvider dbProvider, IQueryableLoginProvider qLoginProvider)
    {
        return new List<IQueryableLogin>(dbProvider.Database.Logins.All().Select(l => qLoginProvider.FromDBO(l)));
    }
}
