namespace Fiicode25Auth.API.Exceptions;

public class UsernameFormatException : FormatException
{
    public override string ErrorCode => $"{base.ErrorCode}_USERNAME";

    public UsernameFormatException() : base("Improperly formatted username") {}
    
    public UsernameFormatException(string message) : base(message) {}
    
    public UsernameFormatException(string message, Exception innerException) : base(message, innerException) {}
}
