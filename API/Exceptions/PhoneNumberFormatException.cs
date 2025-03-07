namespace Fiicode25Auth.API.Exceptions;

public class PhoneNumberFormatException : FormatException
{
    public override string ErrorCode => $"{base.ErrorCode}_PHONE";

    public PhoneNumberFormatException() : base("Phone number is not in a valid format. Please use E.164 format") {}
    
    public PhoneNumberFormatException(string message) : base(message) {}
    
    public PhoneNumberFormatException(string message, Exception innerException) : base(message, innerException) {}
}