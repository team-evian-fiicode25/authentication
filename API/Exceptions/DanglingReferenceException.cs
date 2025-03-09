namespace Fiicode25Auth.API.Exceptions;

public class MissingItemException : GraphQLExposedException
{
    public override string ErrorCode => "MISSING";

    public MissingItemException()
    {
    }

    public MissingItemException(string? message) : base(message)
    {
    }

    public MissingItemException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
