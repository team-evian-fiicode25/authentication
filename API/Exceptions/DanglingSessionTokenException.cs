namespace Fiicode25Auth.API.Exceptions;

public class DanglingSessionTokenException : MissingItemException
{
    public override string ErrorCode => $"{base.ErrorCode}_STOKEN";

    public DanglingSessionTokenException() 
        : base("Could not get corresponding login")
    {}
}

