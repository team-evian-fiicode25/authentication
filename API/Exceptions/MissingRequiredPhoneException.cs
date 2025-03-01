
namespace Fiicode25Auth.API.Exceptions;

public class MissingRequiredPhoneException : MissingRequiredArgumentException
{
    public override string ErrorCode => $"{base.ErrorCode}_PHONE";

    public MissingRequiredPhoneException() : base("Missing required argument: phoneNumber")
    {
    }
}

