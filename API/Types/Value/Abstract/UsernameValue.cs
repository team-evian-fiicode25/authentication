namespace Fiicode25Auth.API.Types.Value.Abstract;

public abstract class UsernameValue : IEquatable<UsernameValue>
{
    public abstract string Value { get; protected set; }

    public bool Equals(UsernameValue? other)
    {
        return other != null && Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString() => Value;
    public static implicit operator string(UsernameValue username) => username.Value;
}
