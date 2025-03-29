using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class InsecurePasswordProvider : IPasswordProvider
{
    public IPassword FromHash(string passwordHash)
        => new InsecurePassword()
        {
            Hash = passwordHash
        };

    public IPassword New(string password)
        => FromHash(password);
}

