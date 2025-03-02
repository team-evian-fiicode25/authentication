namespace Fiicode25Auth.API.Exceptions;

public class DanglingSessionTokenException : DanglingReferenceException
{
    public override string ErrorCode => $"{base.ErrorCode}_STOKEN";

    public DanglingSessionTokenException() 
        : base("Could not get corresponding login")
    {}
}

