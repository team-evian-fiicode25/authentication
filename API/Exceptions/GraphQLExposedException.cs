namespace Fiicode25Auth.API.Exceptions;

[Serializable]
public abstract class GraphQLExposedException : Exception
{
    public abstract string ErrorCode {get;}

    protected GraphQLExposedException()
    {
    }

    protected GraphQLExposedException(string? message) : base(message)
    {
    }

    protected GraphQLExposedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

