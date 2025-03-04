using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.API.Types.Helper.LoginSession;

public class NOfMLoginSessionProvider : ILoginSessionProvider
{
    public ILoginSession New(ILogin login)
    {
        if (login.Id == null)
        {
            throw new ArgumentException(
                    "Cannot create a login session for a login that is not commited to the db"
                    );
        }

        return new NOfMLoginSession(
            loginId: login.Id.Value,
            expiresAt: DateTime.UtcNow + TimeSpan.FromMinutes(10),
            email: _getEmail2FA(login),
            phone: _getPhone2FA(login),
            tokenGenerator: _tokenGenerator);
    }

    public ILoginSession FromDBO(LoginSessionWith2FAData loginSession)
        => new NOfMLoginSession(
            id: loginSession.LoginSession.Id,
            identifyingToken: loginSession.LoginSession.SecureIdentifier,
            expiresAt: loginSession.LoginSession.Expiration,
            loginId: loginSession.LoginSession.LoginId,
            phone: _getPhone2FA(loginSession),
            email: _getEmail2FA(loginSession),
            tokenGenerator: _tokenGenerator);



    public Database.DBObjects.LoginSession ToDBO(ILoginSession loginSession) => new()
    {
        Id=loginSession.Id ?? Guid.Empty,
        SecureIdentifier=loginSession.IdentifyingToken,
        EmailToken=loginSession.Email?.VerifyCode,
        SMSCode=loginSession.Phone?.VerifyCode,
        LoginId=loginSession.LoginId,
        Expiration=loginSession.ExpiresAt
    };

    public NOfMLoginSessionProvider(IEmail2FAProvider email2FAProvider, IPhone2FAProvider phone2FAProvider, IEmailProvider emailProvider, IPhoneNumberProvider phoneProvider, ISecureTokenGenerator tokenGenerator)
    {
        _email2FAProvider = email2FAProvider;
        _phone2FAProvider = phone2FAProvider;
        _emailProvider = emailProvider;
        _phoneProvider = phoneProvider;
        _tokenGenerator = tokenGenerator;
    }

    private IEmail2FAProvider _email2FAProvider;
    private IPhone2FAProvider _phone2FAProvider;
    private IEmailProvider _emailProvider;
    private IPhoneNumberProvider _phoneProvider;
    private ISecureTokenGenerator _tokenGenerator;

    private IEmail2FA? _getEmail2FA(ILogin login) => _nullOnException(() =>
    {
        if (login.Email != null)
            return _email2FAProvider.New(login.Email);

        return null;
    });

    private IEmail2FA? _getEmail2FA(LoginSessionWith2FAData loginSession) => _nullOnException(() =>
    {
        if (loginSession.Email == null)
            return null;

        return _email2FAProvider
            .FromCode(
                    _emailProvider.FromDBO(loginSession.Email),
                    loginSession.LoginSession.EmailToken);
    });

    private IPhone2FA? _getPhone2FA(ILogin login) => _nullOnException(() => 
    {
        if (login.PhoneNumber == null)
            return null;

        return _phone2FAProvider.New(login.PhoneNumber);
    });

    private IPhone2FA? _getPhone2FA(LoginSessionWith2FAData loginSession) => _nullOnException(() =>
    {
        if (loginSession.PhoneNumber == null)
            return null;

        return _phone2FAProvider
            .FromCode(
                    _phoneProvider.FromDBO(loginSession.PhoneNumber),
                    loginSession.LoginSession.SMSCode);
    });

    private T? _nullOnException<T> (Func<T> f)
    {
        try { return f(); } catch { return default(T); }
    }
}
