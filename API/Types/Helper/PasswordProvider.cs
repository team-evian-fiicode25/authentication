using Fiicode25Auth.API.Types.Helper.Abstract;

namespace Fiicode25Auth.API.Types.Helper;

public class PasswordProvider : IPasswordProvider
{
    public IPassword FromHash(string passwordHash)
        => new Password(passwordHash);

    public IPassword New(string password)
        => Password.FromPassword(password);
}
