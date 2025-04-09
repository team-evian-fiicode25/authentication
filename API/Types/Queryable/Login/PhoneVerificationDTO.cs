using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class PhoneVerificationDTO : IPhoneVerificationDTO
{
    public string? Username { get; init; }

    required public string PhoneNumber { get; init; }

    required public string VerificationCode { get; init; }
}

