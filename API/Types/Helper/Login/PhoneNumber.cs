using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Value;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class PhoneNumber : IPhoneNumber
{
    private readonly PhoneNumberValue _phoneNumberValue;
    
    public string Number => _phoneNumberValue.Value;

    public bool IsVerified {get; private set;}
    public string? VerifyCode {get; private set;}

    public string RequestVerification()
    {
        if (IsVerified)
        {
            throw new GraphQLException("Cannot request verification of an already verified phone number.");
        }

        return VerifyCode=_tokenGenerator.RandomDigits6();
    }

    public void Verify()
    {
        IsVerified=true;
        VerifyCode=null;
    }

    public bool VerifyIfMatches(string code)
    {
        if (VerifyCode != code)
            return false;

        Verify();
        return true;
    }

    public PhoneNumber(string phoneNumber, ISecureTokenGenerator tokenGenerator)
    {
        _phoneNumberValue=PhoneNumberValue.Create(phoneNumber);
        _tokenGenerator=tokenGenerator;
        IsVerified=false;
    }

    public PhoneNumber(string phoneNumber, bool isVerified, string? verifyCode, ISecureTokenGenerator tokenGenerator)
    {
        _phoneNumberValue=PhoneNumberValue.Create(phoneNumber);
        VerifyCode=verifyCode;
        IsVerified=isVerified;
        _tokenGenerator=tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}

