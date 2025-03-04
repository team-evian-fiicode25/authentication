namespace Fiicode25Auth.API.Exceptions;

public class DanglingReferenceException : GraphQLExposedException
{
    public override string ErrorCode => "MISSING";

    public DanglingReferenceException()
    {
    }

    public DanglingReferenceException(string? message) : base(message)
    {
    }

    public DanglingReferenceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

