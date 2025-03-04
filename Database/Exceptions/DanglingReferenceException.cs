namespace Fiicode25Auth.Database.Exceptions;

[Serializable]
public class DanglingReferenceException : Exception
{
    public DanglingReferenceException()
    {
    }

    public DanglingReferenceException(string? message) : base(message)
    {
    }

    public DanglingReferenceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}


