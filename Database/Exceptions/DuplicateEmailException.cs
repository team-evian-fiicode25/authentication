namespace Fiicode25Auth.Database.Exceptions;

[Serializable]
public class DuplicateEmailException : DuplicateFieldException
{
    public DuplicateEmailException()
    {
    }

    public DuplicateEmailException(string? message) : base(message)
    {
    }

    public DuplicateEmailException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}


