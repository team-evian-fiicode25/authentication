using System.Text.RegularExpressions;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Value;

namespace Fiicode25Auth.API.Types.Helper.LoginSession;

public class SolvedPhone2FA : IPhone2FA
{
    private readonly PhoneNumberValue _phoneNumber;
    
    public string Number => _phoneNumber.Value;

    public string? VerifyCode 
        => RequestCode();

    public bool IsSolved => true;

    public string RequestCode()
        => "000000";

    public bool Verify(string code)
        => IsSolved;
    
    public SolvedPhone2FA(string number)
    {
        _phoneNumber = PhoneNumberValue.Create(number);
    }
}

