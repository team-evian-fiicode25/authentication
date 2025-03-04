using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class PhoneNumber : IPhoneNumber
{
    public string Number {get; private set;}

    public bool IsVerified => VerifyCode == null;
    public string? VerifyCode {get; private set;}

    public PhoneNumber(string phoneNumber, ISecureTokenGenerator tokenGenerator)
    {
        Number=phoneNumber;
        VerifyCode=tokenGenerator.RandomDigits6();
    }

    public PhoneNumber(string phoneNumber, string? verifyCode)
    {
        Number=phoneNumber;
        VerifyCode=verifyCode;
    }
}

