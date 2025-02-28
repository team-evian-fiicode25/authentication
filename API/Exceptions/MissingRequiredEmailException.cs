
namespace Fiicode25Auth.API.Exceptions;

public class MissingRequiredEmailException : MissingRequiredArgumentException
{
    public override string ErrorCode => $"{base.ErrorCode}_EMAIL";

    public MissingRequiredEmailException() : base("Missing required argument: email")
    {
    }
}

