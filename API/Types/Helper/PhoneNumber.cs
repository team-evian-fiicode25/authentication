using Fiicode25Auth.API.Types.Helper.Abstract;

namespace Fiicode25Auth.API.Types.Helper;

public class PhoneNumber : IPhoneNumber
{
    public string Number {get; private set;}

    public bool IsVerified => VerifyCode == null;
    public string? VerifyCode {get; private set;}

    public PhoneNumber(string phoneNumber)
    {
        Number=phoneNumber;
        VerifyCode=_generateCode();
    }

    public PhoneNumber(string phoneNumber, string? verifyCode)
    {
        Number=phoneNumber;
        VerifyCode=verifyCode;
    }

    private string _generateCode() 
        => (new Random().NextInt64() % (int)Math.Pow(10, 6)).ToString();
}

