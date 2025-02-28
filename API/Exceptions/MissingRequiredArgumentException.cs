
namespace Fiicode25Auth.API.Exceptions;

public class MissingRequiredArgumentException : GraphQLExposedException
{
    public MissingRequiredArgumentException()
    {
    }

    public MissingRequiredArgumentException(string? message) : base(message)
    {
    }

    public MissingRequiredArgumentException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public override string ErrorCode => "MISSING";
}
