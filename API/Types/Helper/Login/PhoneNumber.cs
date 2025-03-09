using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Value;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class PhoneNumber : IPhoneNumber
{
    private readonly PhoneNumberValue _phoneNumberValue;
    
    public string Number => _phoneNumberValue.Value;

    public bool IsVerified => VerifyCode == null;
    public string? VerifyCode {get; private set;}

    public string RequestVerification()
    {
        if (IsVerified)
        {
            throw new GraphQLException("Cannot request verification of an already verified phone number.");
        }

        return VerifyCode=_tokenGenerator.RandomDigits6();
    }

    public PhoneNumber(string phoneNumber, ISecureTokenGenerator tokenGenerator)
    {
        _phoneNumberValue=PhoneNumberValue.Create(phoneNumber);
        _tokenGenerator=tokenGenerator;
        VerifyCode=tokenGenerator.RandomDigits6();
    }

    public PhoneNumber(string phoneNumber, string? verifyCode, ISecureTokenGenerator tokenGenerator)
    {
        _phoneNumberValue=PhoneNumberValue.Create(phoneNumber);
        VerifyCode=verifyCode;
        _tokenGenerator=tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}

