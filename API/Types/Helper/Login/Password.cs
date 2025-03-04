using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class Password : IPassword
{
    public string Hash {get; private set;}

    public bool Verify(string password)
        => BCrypt.Net.BCrypt.Verify(password, Hash);

    public Password(string passwordHash) => Hash=passwordHash;

    public static Password FromPassword(string password)
        => new(BCrypt.Net.BCrypt.HashPassword(password));
}
