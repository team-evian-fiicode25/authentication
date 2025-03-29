namespace Fiicode25Auth.API.Exceptions;

public class PasswordFormatException : FormatException
{
    public override string ErrorCode => $"{base.ErrorCode}_PASSWORD";

    public PasswordFormatException() : base("Improperly formatted password") {}
    
    public PasswordFormatException(string message) : base(message) {}
    
    public PasswordFormatException(string message, Exception innerException) : base(message, innerException) {}
}

