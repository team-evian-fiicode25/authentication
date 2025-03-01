namespace Fiicode25Auth.Database.Exceptions;

[Serializable]
public class DuplicateUsernameException : DuplicateFieldException
{
    public DuplicateUsernameException()
    {
    }

    public DuplicateUsernameException(string? message) : base(message)
    {
    }

    public DuplicateUsernameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
