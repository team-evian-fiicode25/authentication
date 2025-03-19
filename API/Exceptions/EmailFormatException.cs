namespace Fiicode25Auth.API.Exceptions;

public class EmailFormatException : FormatException
{
    public override string ErrorCode => $"{base.ErrorCode}_EMAIL";

    public EmailFormatException() : base("Wrongly formatted email")
    {
    }
}

