namespace Fiicode25Auth.API.Exceptions;

public class IdFormatException : FormatException
{
    public override string ErrorCode => $"{base.ErrorCode}_ID";

    public IdFormatException() : base("Wrongly formatted id") {}
}

