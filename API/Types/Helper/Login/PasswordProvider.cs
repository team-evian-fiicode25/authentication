using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class PasswordProvider : IPasswordProvider
{
    public IPassword FromHash(string passwordHash)
        => new Password(passwordHash);

    public IPassword New(string password)
        => Password.FromPassword(password);
}
