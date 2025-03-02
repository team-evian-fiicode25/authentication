using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.Login;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;

namespace Fiicode25Auth.API.GraphQL.Services;

public class LoginService : ILoginService
{
    public async Task<IQueryableLogin> Create(string password,
                                              string? username = null,
                                              string? email = null,
                                              string? phoneNumber = null)
    {
        var login = _loginProviders.Login.NewWithPassword(password);

        if (username == null && _config.MandatoryFields.HasFlag(Fields.Username))
            throw new MissingRequiredUsernameException();
        login.Username = username;

        if (email != null)
            login.Email = _loginProviders.Email.NewFromAddress(email);
        else if (_config.MandatoryFields.HasFlag(Fields.Email))
            throw new MissingRequiredEmailException();

        if (phoneNumber != null)
            login.PhoneNumber = _loginProviders.Phone.New(phoneNumber);
        else if (_config.MandatoryFields.HasFlag(Fields.Phone))
            throw new MissingRequiredPhoneException();

        var loginDBO = await _dbProvider.Database.Logins.Commit(_loginProviders.Login.ToDBO(login));

        return _qLoginProvider.FromDBO(loginDBO);
    }

    public async Task<IQueryableLogin?> Get(string? id = null,
                                            string? username = null,
                                            string? email = null,
                                            string? phone = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email);

        if (dbo == null)
            return null;

        return _qLoginProvider.FromDBO(dbo);
    }

    public async Task<IQueryableLogin?> Remove(string? id = null,
                                               string? username = null,
                                               string? email = null,
                                               string? phone = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email);
        if (dbo == null)
            return null;

        dbo = await _dbProvider.Database.Logins.Remove(dbo.Id);
        if (dbo == null)
            throw new Exception();

        return _qLoginProvider.FromDBO(dbo);
    }

    public LoginService(IDatabaseProvider dbProvider, AllLoginProviders loginProviders, IQueryableLoginProvider qLoginProvider, ILoginRetriever loginRetriever, IApplicationConfiguration config)
    {
        _dbProvider = dbProvider;
        _loginProviders = loginProviders;
        _qLoginProvider = qLoginProvider;
        _loginRetriever = loginRetriever;
        _config = config;
    }

    private IDatabaseProvider _dbProvider;
    private AllLoginProviders _loginProviders;
    private IQueryableLoginProvider _qLoginProvider;
    private ILoginRetriever _loginRetriever;
    private IApplicationConfiguration _config;
}
