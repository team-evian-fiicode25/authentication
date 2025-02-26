using Fiicode25Auth.API.Types;
using Fiicode25Auth.API.Types.Abstract;
using Fiicode25Auth.Database;

namespace Fiicode25Auth.API;

public class Query
{
    public List<IQueryableLogin> Logins
        => new List<IQueryableLogin>(Provider.Database.Logins.All().Select(l => new QueryableLogin(l)));
}
