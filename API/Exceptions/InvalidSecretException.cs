namespace Fiicode25Auth.API.Exceptions;

public class InvalidSecretException : GraphQLExposedException
{
    public override string ErrorCode => "WRONG_SECRET";

    public InvalidSecretException(string message) : base(message)
    {
    }
}

