namespace Fiicode25Auth.API.Exceptions;

public class MissingEmailException : MissingItemException
{
    public override string ErrorCode => $"{base.ErrorCode}_EMAIL";

    public MissingEmailException()
        : base("The requested email could not be found.")
    {
    }

    public MissingEmailException(string? message) 
        : base(message)
    {
    }
}

