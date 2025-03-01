using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class LoginProvider : ILoginProvider
{
    public ILogin FromDBO(Database.DBObjects.Login login)
    {
        var l = new Login(
            id: login.Id,
            password: _passwordProvider.FromHash(login.PasswordHash));

        l.Email = login.Email.HasValue ?
            _emailProvider.FromDBO(login.Email.Value) : null;
        l.PhoneNumber = login.PhoneNumber.HasValue ? 
            _phoneNumberProvider.FromDBO(login.PhoneNumber.Value) : null;
        l.Username = login.UserName;

        return l;
    }

    public ILogin NewWithPassword(string password)
        => new Login(_passwordProvider.New(password));

    public Database.DBObjects.Login ToDBO(ILogin login) => new()
    {
        Id = login.Id ?? Guid.Empty,
        UserName = login.Username,
        PasswordHash = login.Password.Hash,
        Email = login.Email != null ? _emailProvider.ToDBO(login.Email) : null,
        PhoneNumber = login.PhoneNumber != null ?
            _phoneNumberProvider.ToDBO(login.PhoneNumber) : null
    };

    public LoginProvider(IEmailProvider emailProvider,
                         IPhoneNumberProvider phoneNumberProvider,
                         IPasswordProvider passwordProvider)
    {
        _emailProvider=emailProvider;
        _phoneNumberProvider=phoneNumberProvider;
        _passwordProvider=passwordProvider;
    }
    private IEmailProvider _emailProvider;
    private IPhoneNumberProvider _phoneNumberProvider;
    private IPasswordProvider _passwordProvider;
}

