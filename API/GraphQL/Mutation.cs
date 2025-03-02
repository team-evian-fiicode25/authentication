using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Mutation 
{
    public Task<IQueryableLogin> CreateLogin(string? username,
                                                   string? email,
                                                   string? phoneNumber,
                                                   string password,
                                                   ILoginService loginService)
        => loginService.Create(username, email, phoneNumber, password);

    public Task<IQueryableLogin?> RemoveLogin(string? id,
                                              string? username,
                                              string? email,
                                              string? phone,
                                              ILoginService loginService)
        => loginService.Remove(id, username, email, phone);

    public Task<IQueryableLoginSession> LogInWithPassword(string? id,
                                                          string? username,
                                                          string? email,
                                                          string? phone,
                                                          string password,
                                                          ILoginSessionService loginSessionService)
        => loginSessionService.LogInWithPassword(id, username, email, phone, password);
}
