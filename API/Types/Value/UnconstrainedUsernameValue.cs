using Fiicode25Auth.API.Types.Value.Abstract;

namespace Fiicode25Auth.API.Types.Value;

public class UnconstrainedUsernameValue : UsernameValue
{
    public UnconstrainedUsernameValue(string value)
    {
        Value = value;
    }

    public override string Value { get; protected set; }
}

