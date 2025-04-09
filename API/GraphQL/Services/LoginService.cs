using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.Login;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.Database.DBs.Abstract;
using HotChocolate.Subscriptions;

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
        if (username != null)
            login.Username = _loginProviders.UsernameValue.Create(username);

        if (email != null)
            login.Email = _loginProviders.Email.NewFromAddress(email);
        else if (_config.MandatoryFields.HasFlag(Fields.Email))
            throw new MissingRequiredEmailException();

        if (phoneNumber != null)
            login.PhoneNumber = _loginProviders.Phone.New(phoneNumber);
        else if (_config.MandatoryFields.HasFlag(Fields.Phone))
            throw new MissingRequiredPhoneException();

        var loginDBO = await _dbProvider.Database.Logins.Commit(_loginProviders.Login.ToDBO(login));
        var qLogin = _qLoginProvider.FromDBO(loginDBO);

        await _eventSender.SendAsync(nameof(Subscription.LoginCreated), qLogin);

        return qLogin;
    }

    public async Task<IQueryableLogin?> Get(string? id = null,
                                            string? username = null,
                                            string? email = null,
                                            string? phone = null,
                                            string? sessionToken = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email, sessionToken);

        if (dbo == null)
            return null;

        return _qLoginProvider.FromDBO(dbo);
    }

    public async Task<IQueryableLogin?> Remove(string? id = null,
                                               string? username = null,
                                               string? email = null,
                                               string? phone = null,
                                               string? sessionToken = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email, sessionToken);
        if (dbo == null)
            return null;

        dbo = await _dbProvider.Database.Logins.Remove(dbo.Id);
        if (dbo == null)
            throw new Exception();

        return _qLoginProvider.FromDBO(dbo);
    }

    public async Task<IQueryableLogin> VerifyEmail(string verificationToken,
                                                   string? id = null,
                                                   string? username = null,
                                                   string? email = null,
                                                   string? phone = null,
                                                   string? sessionToken = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email, sessionToken);

        if (dbo == null)
            throw new MissingLoginException();

        var login = _loginProviders.Login.FromDBO(dbo);

        if (login.Email == null)
            throw new MissingEmailException();

        var success = login.Email.VerifyIfMatches(verificationToken);

        if (!success)
            throw new InvalidSecretException("Wrong token provided");

        dbo = await _dbProvider.Database.Logins.Commit(_loginProviders.Login.ToDBO(login));

        return _qLoginProvider.FromDBO(dbo);
    }

    public async Task<IEmailVerificationDTO> RequestEmailVerification(string? id = null,
                                                                      string? username = null,
                                                                      string? email = null,
                                                                      string? phone = null,
                                                                      string? sessionToken = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email, sessionToken);

        if (dbo == null)
            throw new MissingLoginException();

        var login = _loginProviders.Login.FromDBO(dbo);

        if (login.Email == null)
            throw new MissingEmailException("Cannot request verification for a non-existing email");

        login.Email.RequestVerification();

        dbo = await _dbProvider.Database.Logins.Commit(_loginProviders.Login.ToDBO(login));

        var dto = _loginProviders.EmailVerificationDTO.FromDBO(dbo);
        await _eventSender.SendAsync(nameof(Subscription.EmailVerificationRequested), dto);

        return dto;
    }

    public async Task<IPhoneVerificationDTO> RequestPhoneNumberVerification(string? id = null,
                                                                            string? username = null,
                                                                            string? email = null,
                                                                            string? phone = null,
                                                                            string? sessionToken = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email, sessionToken);

        if (dbo == null)
            throw new MissingLoginException();

        var login = _loginProviders.Login.FromDBO(dbo);

        if (login.PhoneNumber == null)
            throw new MissingPhoneNumberException("Cannot request verification for a non-existing phone number");

        login.PhoneNumber.RequestVerification();

        dbo = await _dbProvider.Database.Logins.Commit(_loginProviders.Login.ToDBO(login));

        var dto = _loginProviders.PhoneVerificationDTO.FromDBO(dbo);
        await _eventSender.SendAsync(nameof(Subscription.PhoneVerificationRequested), dto);

        return dto;
    }


    public async Task<IQueryableLogin> VerifyPhoneNumber(string verificationCode,
                                                         string? id = null,
                                                         string? username = null,
                                                         string? email = null,
                                                         string? phone = null,
                                                         string? sessionToken = null)
    {
        var dbo = await _loginRetriever.GetByIdentifier(id, username, phone, email, sessionToken);

        if (dbo == null)
            throw new MissingLoginException();

        var login = _loginProviders.Login.FromDBO(dbo);

        if (login.PhoneNumber == null)
            throw new MissingPhoneNumberException();

        var success = login.PhoneNumber.VerifyIfMatches(verificationCode);

        if (!success)
            throw new InvalidSecretException("Wrong code provided");

        dbo = await _dbProvider.Database.Logins.Commit(_loginProviders.Login.ToDBO(login));

        return _qLoginProvider.FromDBO(dbo);
    }

    public LoginService(IDatabaseProvider dbProvider,
                        AllLoginProviders loginProviders,
                        IQueryableLoginProvider qLoginProvider,
                        ILoginRetriever loginRetriever,
                        ITopicEventSender eventSender,
                        IApplicationConfiguration config)
    {
        _dbProvider = dbProvider;
        _loginProviders = loginProviders;
        _qLoginProvider = qLoginProvider;
        _loginRetriever = loginRetriever;
        _eventSender = eventSender;
        _config = config;
    }

    private IDatabaseProvider _dbProvider;
    private AllLoginProviders _loginProviders;
    private IQueryableLoginProvider _qLoginProvider;
    private ILoginRetriever _loginRetriever;
    private ITopicEventSender _eventSender;
    private IApplicationConfiguration _config;
}

