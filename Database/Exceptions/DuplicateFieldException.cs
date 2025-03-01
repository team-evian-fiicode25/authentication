namespace Fiicode25Auth.Database.Exceptions;

[Serializable]
public class DuplicateFieldException : Exception
{
    public DuplicateFieldException()
    {
    }

    public DuplicateFieldException(string? message) : base(message)
    {
    }

    public DuplicateFieldException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
