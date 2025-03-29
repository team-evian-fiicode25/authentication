using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class InsecurePassword : IPassword
{
    public required string Hash {get; set;}

    public bool Verify(string password)
        => Hash == password;
}

