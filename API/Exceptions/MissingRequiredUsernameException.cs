
namespace Fiicode25Auth.API.Exceptions;

public class MissingRequiredUsernameException : MissingRequiredArgumentException
{
    public override string ErrorCode => $"{base.ErrorCode}_USN";

    public MissingRequiredUsernameException() : base("Missing required argument: username")
    {
    }
}

