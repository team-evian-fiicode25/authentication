using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;

namespace Fiicode25Auth.API.GraphQL.Services.Abstract;

public interface ILoginSessionService 
{
    Task<IQueryableLoginSession?> Get(string token);
    Task<IQueryableLoginSession> LogInWithPassword(string? id,
                                                   string? username,
                                                   string? email,
                                                   string? phone,
                                                   string password);
}

