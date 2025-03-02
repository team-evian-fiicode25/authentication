using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.GraphQL.Services.Abstract;

public interface ISessionService
{
    Task<IQueryableSessionToken?> MakeSessionToken(string loginId, string sessionToken);
}

