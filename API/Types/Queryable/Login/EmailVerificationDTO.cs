using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class EmailVerificationDTO : IEmailVerificationDTO
{
    required public string UserId { get; init; }

    public string? Username { get; init; }

    required public string Email { get; init; }

    required public string VerificationToken { get; init; }
}
