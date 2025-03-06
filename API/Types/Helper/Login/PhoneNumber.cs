using System.Text.RegularExpressions;
using Fiicode25Auth.API.Exceptions;
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

    public PhoneNumber(string phoneNumber, ISecureTokenGenerator tokenGenerator)
    {
        _phoneNumberValue=PhoneNumberValue.Create(phoneNumber);
        VerifyCode=tokenGenerator.RandomDigits6();
    }

    public PhoneNumber(string phoneNumber, string? verifyCode)
    {
        _phoneNumberValue=PhoneNumberValue.Create(phoneNumber);
        VerifyCode=verifyCode;
    }
}

