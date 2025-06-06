namespace Fiicode25Auth.API.Exceptions;

public class DanglingLoginSessionException : MissingItemException
{
    public override string ErrorCode => $"{base.ErrorCode}_LOGIN";

    public DanglingLoginSessionException() 
        : base("Could not get corresponding login")
    {}
}
