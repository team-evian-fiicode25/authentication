using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.Types.Helper;
using Fiicode25Auth.API.Types.Queryable.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Mutation 
{
    public async Task<IQueryableLogin> CreateLogin(string? username,
                                                   string? email,
                                                   string? phoneNumber,
                                                   string password,
                                                   IDatabaseProvider dbProvider,
                                                   AllLoginProviders loginProviders,
                                                   IQueryableLoginProvider qLoginProvider,
                                                   IApplicationConfiguration config)
    {
        var login = loginProviders.Login.NewWithPassword(password);

        if (username == null && config.MandatoryFields.HasFlag(Fields.Username))
            throw new GraphQLException("Missing required argument: User");
        login.Username = username;

        if (email != null)
            login.Email = loginProviders.Email.NewFromAddress(email);
        else if (config.MandatoryFields.HasFlag(Fields.Email))
            throw new GraphQLException("Missing required argument: Email");

        if (phoneNumber != null)
            login.PhoneNumber = loginProviders.Phone.New(phoneNumber);
        else if (config.MandatoryFields.HasFlag(Fields.Phone))
            throw new GraphQLException("Missing required argument: Phone");

        var loginDBO = await dbProvider.Database.Logins.Commit(loginProviders.Login.ToDBO(login));

        return qLoginProvider.FromDBO(loginDBO);
    }
}
