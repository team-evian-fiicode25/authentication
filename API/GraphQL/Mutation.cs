using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.Types.Helper.Login;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;
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
            throw new MissingRequiredUsernameException();
        login.Username = username;

        if (email != null)
            login.Email = loginProviders.Email.NewFromAddress(email);
        else if (config.MandatoryFields.HasFlag(Fields.Email))
            throw new MissingRequiredEmailException();

        if (phoneNumber != null)
            login.PhoneNumber = loginProviders.Phone.New(phoneNumber);
        else if (config.MandatoryFields.HasFlag(Fields.Phone))
            throw new MissingRequiredPhoneException();

        var loginDBO = await dbProvider.Database.Logins.Commit(loginProviders.Login.ToDBO(login));

        return qLoginProvider.FromDBO(loginDBO);
    }

    public async Task<IQueryableLogin?> RemoveLogin(string id,
                                                    IDatabaseProvider dbProvider,
                                                    IQueryableLoginProvider qLoginProvider)
    {
        try 
        {
            var dbo = await dbProvider.Database.Logins.Remove(Guid.Parse(id));
            if(dbo == null)
                return null;

            return qLoginProvider.FromDBO(dbo);
        }
        catch (System.FormatException)
        {
            throw new IdFormatException();
        }
    }

    public async Task<IQueryableLoginSession> LogInWithPassword(string username,
                                                         string password,
                                                         IDatabaseProvider dbProvider,
                                                         ILoginProvider loginProvider,
                                                         ILoginSessionProvider loginSessionProvider,
                                                         IQueryableLoginSessionProvider qLoginSessionProvider)
    {
        var loginDBO = await dbProvider.Database.Logins.ByUsername(username);
        if (loginDBO == null)
            throw new GraphQLException("Wrong credentials");

        var login = loginProvider.FromDBO(loginDBO);

        if (!login.Password.Verify(password))
            throw new GraphQLException("Wrong credentials");

        var loginSession = loginSessionProvider.New(login);

        // TODO: Update interface to return LoginSessionWith2FAData instead
        var loginSessionToken
            = (await dbProvider.Database.LoginSessions.Commit(
                    loginSessionProvider.ToDBO(loginSession)
                )).SecureIdentifier;

        var loginSessionDBO = await dbProvider.Database.LoginSessions.Get(loginSessionToken);

        return qLoginSessionProvider.FromDBO(loginSessionDBO);
    }
}
