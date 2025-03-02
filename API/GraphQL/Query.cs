using Fiicode25Auth.API.GraphQL.Services.Abstract;
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

    public Task<IQueryableLogin?> GetLogin(string? id,
                                           string? username,
                                           string? email,
                                           string? phone,
                                           string? sessionToken,
                                           ILoginService loginService)
        => loginService.Get(id, username, email, phone, sessionToken);

    public Task<IQueryableLoginSession?> GetLoginSession(string token, ILoginSessionService loginSessionService)
        => loginSessionService.Get(token);
}
