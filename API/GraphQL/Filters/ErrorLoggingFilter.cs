namespace Fiicode25Auth.API.GraphQL.Filters;

/// <summary>
///     Filter to log unexpected exceptions to stderr
/// </summary>
public class ErrorLoggingFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        if (error.Exception != null && error.Code == null)
        {
            Console.Error.WriteLine(error.Exception.ToString());
        }
        return error;
    }
}
