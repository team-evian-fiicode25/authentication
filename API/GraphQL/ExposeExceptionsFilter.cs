using Fiicode25Auth.API.Exceptions;

namespace Fiicode25Auth.API.GraphQL;

/// <summary>
///     Filter to expose messages of intended
///     exceptions to the API
/// <summary>
public class ExposeExceptionsFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        var exc = error.Exception as GraphQLExposedException;
        if(exc == null)
        {
            return error;
        }

        return error
            .WithCode(exc.ErrorCode)
            .WithMessage(exc.Message);
    }
}

