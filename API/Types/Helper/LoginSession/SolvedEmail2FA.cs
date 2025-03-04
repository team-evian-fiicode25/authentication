using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession;

public class SolvedEmail2FA : IEmail2FA
{
    public string Address {get; private set;}

    public string? VerifyCode 
        => RequestCode();

    public bool IsSolved => true;

    public string RequestCode()
        => "000000";

    public bool Verify(string code)
        => IsSolved;

    public SolvedEmail2FA(string address)
    {
        Address = address;
    }
}
