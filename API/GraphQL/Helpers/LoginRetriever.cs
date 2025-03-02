using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL.Helpers;

public class LoginRetriever : ILoginRetriever
{
    public Task<Login?> GetByIdentifier(string? id,
                                        string? username,
                                        string? phoneNumber,
                                        string? email,
                                        string? sessionToken)
    {
        var paramCount = new List<string?>{username, phoneNumber, email, id, sessionToken}
            .Where(x => x != null)
            .Count();

        if (paramCount > 1)
            throw new GraphQLException("Too many parameters. Expected exactly one of: id, username, phoneNumber, email, sessionToken");

        if (id != null)
        {
            try
            {
                return _databaseProvider.Database.Logins.ById(Guid.Parse(id));
            }
            catch (System.FormatException)
            {
                throw new IdFormatException();
            }
        }

        if (username != null)
            return _databaseProvider.Database.Logins.ByUsername(username);

        if (phoneNumber != null)
            return _databaseProvider.Database.Logins.ByPhoneNumber(phoneNumber);

        if (email != null)
            return _databaseProvider.Database.Logins.ByEmail(email);

        if (sessionToken != null)
            return _databaseProvider.Database.Logins.BySessionToken(sessionToken);

        throw new GraphQLException("Expected on of: id, username, phoneNumber, email, sessionToken");
    }

    public LoginRetriever(IDatabaseProvider databaseProvider)
    {
        _databaseProvider = databaseProvider;
    }

    private IDatabaseProvider _databaseProvider;
}
