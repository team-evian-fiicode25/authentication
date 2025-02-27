using Fiicode25Auth.Database.Exceptions;

namespace Fiicode25Auth.API.GraphQL;

/// <summary>
///     Filter to expose some exceptions thrown in the database layer
///     directly to the API
/// </summary>
public class DatabaseExceptionFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        if(error.Exception is DuplicateUsernameException)
        {
            return error
                .WithCode("DUP_USN")
                .WithMessage("Failed unique constraint on the username field");
        }


        if (error.Exception != null)
        {
            Console.Error.WriteLine(error.Exception.ToString());
        }
        return error;
    }
}
