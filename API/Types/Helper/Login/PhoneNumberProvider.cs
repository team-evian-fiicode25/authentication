using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class PhoneNumberProvider : IPhoneNumberProvider
{
    public IPhoneNumber New(string phoneNumber)
        => new PhoneNumber(phoneNumber, _tokenGenerator);

    public IPhoneNumber FromDBO(Database.DBObjects.PhoneNumber phoneNumber)
        => new PhoneNumber(phoneNumber.Number, phoneNumber.IsVerified, phoneNumber.VerifyCode, _tokenGenerator);

    public Database.DBObjects.PhoneNumber ToDBO(IPhoneNumber phoneNumber) => new()
    {
        Number=phoneNumber.Number,
        VerifyCode=phoneNumber.VerifyCode,
        IsVerified=phoneNumber.IsVerified
    };

    public PhoneNumberProvider(ISecureTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}

