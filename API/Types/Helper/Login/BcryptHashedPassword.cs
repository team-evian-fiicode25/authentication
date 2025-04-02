using System.Text.RegularExpressions;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class BcryptHashedPassword : IPassword
{
    public string Hash {get; private set;}

    public bool Verify(string password)
        => BCrypt.Net.BCrypt.Verify(password, Hash);

    public BcryptHashedPassword(string passwordHash) => Hash=passwordHash;

    public static BcryptHashedPassword FromPassword(string password)
    {
        _validatePassword(password);

        return new(BCrypt.Net.BCrypt.HashPassword(password));
    }

    private static void _validatePassword(string password)
    {
        if (password.Length < 8)
        {
            throw new PasswordFormatException("Passwords must be at least 8 characters long");
        }

        if (Regex.IsMatch(password, @"\s"))
        {
            throw new PasswordFormatException("Passwords must not contain any whitespace");
        }

        var lowercaseChars = Enumerable
            .Range('a', 'z' - 'a' + 1)
            .Select(ch => (char)ch);

        if (!password.Any(ch => lowercaseChars.Contains(ch)))
        {
            throw new PasswordFormatException("Passwords should contain at least one lowercase character");
        }

        var uppercaseChars = Enumerable
            .Range('A', 'Z' - 'A' + 1)
            .Select(ch => (char)ch);

        if (!password.Any(ch => uppercaseChars.Contains(ch)))
        {
            throw new PasswordFormatException("Passwords should contain at least one uppercase character");
        }

        var numericalChars = Enumerable
            .Range('0', 10)
            .Select(ch => (char)ch);

        if (!password.Any(ch => numericalChars.Contains(ch)))
        {
            throw new PasswordFormatException("Passwords should contain at least one number");
        }

        if (!password.Any(ch =>
                    !numericalChars.Contains(ch) &&
                    !lowercaseChars.Contains(ch) &&
                    !uppercaseChars.Contains(ch)))
        {
            throw new PasswordFormatException("Passwords should contain at least one special character");
        }
    }
}
