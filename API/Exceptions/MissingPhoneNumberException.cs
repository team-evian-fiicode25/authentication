namespace Fiicode25Auth.API.Exceptions;

public class MissingPhoneNumberException : MissingItemException
{
    public override string ErrorCode => $"{base.ErrorCode}_PHONE";

    public MissingPhoneNumberException()
        : base("The requested phone number could not be found.")
    {
    }

    public MissingPhoneNumberException(string? message) 
        : base(message)
    {
    }
}

