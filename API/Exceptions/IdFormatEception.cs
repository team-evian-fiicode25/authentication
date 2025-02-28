namespace Fiicode25Auth.API.Exceptions;

public class IdFormatEception : FormatException
{
    public override string ErrorCode => $"{base.ErrorCode}_ID";

    public IdFormatEception() : base("Wrongly formatted id") {}
}

