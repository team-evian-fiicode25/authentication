using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.API.GraphQL.Helpers.Abstract;

public interface ILoginRetriever
{
    Task<Login?> GetByIdentifier(string? id = null,
                                 string? username = null,
                                 string? phoneNumber = null,
                                 string? email = null,
                                 string? sessionToken = null);
}
