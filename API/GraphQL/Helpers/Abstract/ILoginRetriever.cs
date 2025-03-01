using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.API.GraphQL.Helpers.Abstract;

public interface ILoginRetriever
{
    Task<Login?> GetByIdentifier(string? id, string? username, string? phoneNumber, string? email);
}
