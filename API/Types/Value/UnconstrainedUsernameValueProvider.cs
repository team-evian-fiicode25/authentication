using Fiicode25Auth.API.Types.Value.Abstract;

namespace Fiicode25Auth.API.Types.Value;

public class UnconstrainedUsernameValueProvider : IUsernameValueProvider
{
    public UsernameValue Create(string value)
    {
        return new UnconstrainedUsernameValue(value);
    }
}

