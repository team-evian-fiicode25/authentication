using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.GraphQL.Services.Abstract;

public interface ILoginService
{
    Task<IQueryableLogin?> Get(string? id, string? username, string? email, string? phone);
    Task<IQueryableLogin> Create(string? username, string? email, string? phoneNumber, string password);
    Task<IQueryableLogin?> Remove(string? id, string? username, string? email, string? phone);
}
