namespace Fiicode25Auth.API.Exceptions;

public class MissingLoginException : MissingItemException
{
    public override string ErrorCode => $"{base.ErrorCode}_LOGIN";

    public MissingLoginException()
        : base("The requested login could not be found.")
    {
    }

    public MissingLoginException(string? message) : base(message)
    {
    }
}
