using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class BcryptHashedPasswordProvider : IPasswordProvider
{
    public IPassword FromHash(string passwordHash)
        => new BcryptHashedPassword(passwordHash);

    public IPassword New(string password)
        => BcryptHashedPassword.FromPassword(password);
}

