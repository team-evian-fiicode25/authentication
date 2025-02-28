namespace Fiicode25Auth.API.Exceptions;

public class FormatException : GraphQLExposedException
{
    public override string ErrorCode => "FMT";

    public FormatException()
    {
    }

    public FormatException(string? message) : base(message)
    {
    }

    public FormatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

