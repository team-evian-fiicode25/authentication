using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Subscription
{
    [Subscribe]
    public IQueryableLogin LoginCreated([EventMessage] IQueryableLogin login)
        => login;

    [Subscribe]
    public IEmailVerificationDTO EmailVerificationRequested([EventMessage] IEmailVerificationDTO login)
        => login;

    [Subscribe]
    public IPhoneVerificationDTO PhoneVerificationRequested([EventMessage] IPhoneVerificationDTO login)
        => login;
}
