namespace Fiicode25Auth.Database.Exceptions;

[Serializable]
public class DuplicatePhoneNumberException : DuplicateFieldException
{
    public DuplicatePhoneNumberException()
    {
    }

    public DuplicatePhoneNumberException(string? message) : base(message)
    {
    }

    public DuplicatePhoneNumberException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
