using System.Text.RegularExpressions;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class PhoneNumberProvider : IPhoneNumberProvider
{
    public IPhoneNumber New(string phoneNumber)
        => new PhoneNumber(phoneNumber, _tokenGenerator);

    public IPhoneNumber FromDBO(Database.DBObjects.PhoneNumber phoneNumber)
        => new PhoneNumber(phoneNumber.Number, phoneNumber.VerifyCode);

    public Database.DBObjects.PhoneNumber ToDBO(IPhoneNumber phoneNumber) => new()
    {
        Number=phoneNumber.Number,
        VerifyCode=phoneNumber.VerifyCode
    };

    public PhoneNumberProvider(ISecureTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}

