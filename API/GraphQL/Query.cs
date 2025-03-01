using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Query
{
    public List<IQueryableLogin> Logins(IDatabaseProvider dbProvider, IQueryableLoginProvider qLoginProvider)
    {
        return new List<IQueryableLogin>(dbProvider.Database.Logins.All().Select(l => qLoginProvider.FromDBO(l)));
    }

    public async Task<IQueryableLogin?> GetLogin(string? id,
                                                 string? username,
                                                 string? email,
                                                 string? phone,
                                                 ILoginRetriever loginRetriever,
                                                 IQueryableLoginProvider qLoginProvider)
    {
        var dbo = await loginRetriever.GetByIdentifier(id, username, phone, email);

        if (dbo == null)
            return null;

        return qLoginProvider.FromDBO(dbo);
    }

    public async Task<IQueryableLoginSession?> GetLoginSession(string token,
                                                               IDatabaseProvider dbProvider,
                                                               IQueryableLoginSessionProvider qLoginSessionProvider)
    {
        var dbo = await dbProvider.Database.LoginSessions.Get(token);
        if(dbo == null)
            return null;

        return qLoginSessionProvider.FromDBO(dbo);
    }
}
