using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Value.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class LoginProvider : ILoginProvider
{
    public ILogin FromDBO(Database.DBObjects.Login login)
    {
        var l = new Login(
            id: login.Id,
            password: _passwordProvider.FromHash(login.PasswordHash),
            sessionTokens: _sessionTokensProvider.FromDBO(login.SessionTokens));

        l.Email = login.Email != null ?
            _emailProvider.FromDBO(login.Email) : null;
        l.PhoneNumber = login.PhoneNumber != null ? 
            _phoneNumberProvider.FromDBO(login.PhoneNumber) : null;
        l.Username = login.UserName != null ?
            _usernameProvider.Create(login.UserName) : null;

        return l;
    }

    public ILogin NewWithPassword(string password)
        => new Login(_passwordProvider.New(password), _sessionTokensProvider.New());

    public Database.DBObjects.Login ToDBO(ILogin login) => new()
    {
        Id = login.Id ?? Guid.Empty,
        UserName = login.Username,
        PasswordHash = login.Password.Hash,
        Email = login.Email != null ? _emailProvider.ToDBO(login.Email) : null,
        PhoneNumber = login.PhoneNumber != null ?
            _phoneNumberProvider.ToDBO(login.PhoneNumber) : null,
        SessionTokens = _sessionTokensProvider.ToDBO(login.SessionTokens)
    };

    public LoginProvider(IUsernameValueProvider usernameProvider,
                         IEmailProvider emailProvider,
                         IPhoneNumberProvider phoneNumberProvider,
                         IPasswordProvider passwordProvider,
                         ISessionTokensProvider sessionTokensProvider)
    {
        _usernameProvider = usernameProvider;
        _emailProvider = emailProvider;
        _phoneNumberProvider = phoneNumberProvider;
        _passwordProvider = passwordProvider;
        _sessionTokensProvider = sessionTokensProvider;
    }

    private IUsernameValueProvider _usernameProvider;
    private IEmailProvider _emailProvider;
    private IPhoneNumberProvider _phoneNumberProvider;
    private IPasswordProvider _passwordProvider;
    private ISessionTokensProvider _sessionTokensProvider;
}

