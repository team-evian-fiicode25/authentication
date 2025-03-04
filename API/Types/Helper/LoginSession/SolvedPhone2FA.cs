using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession;

public class SolvedPhone2FA : IPhone2FA
{
    public string Number {get; private set;}

    public string? VerifyCode 
        => RequestCode();

    public bool IsSolved => true;

    public string RequestCode()
        => "000000";

    public bool Verify(string code)
        => IsSolved;
    
    public SolvedPhone2FA(string number)
    {
        Number = number;
    }
}

