using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Subscription
{
    [Subscribe]
    public IQueryableLogin LoginCreated([EventMessage] IQueryableLogin login)
        => login;

    [Subscribe]
    public IQueryableLogin EmailVerificationRequested([EventMessage] IQueryableLogin login)
        => login;

    [Subscribe]
    public IQueryableLogin PhoneVerificationRequested([EventMessage] IQueryableLogin login)
        => login;
}
