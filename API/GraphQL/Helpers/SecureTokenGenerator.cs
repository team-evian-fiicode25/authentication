using Fiicode25Auth.API.GraphQL.Helpers.Abstract;

namespace Fiicode25Auth.API.GraphQL.Helpers;

public class SecureTokenGenerator : ISecureTokenGenerator
{
    public string Base64Url128Bytes()
    {
        var random = new Random();
        var token = new byte[128];
        random.NextBytes(token);

        char[] padding = { '=' };
        return System.Convert.ToBase64String(token)
        .TrimEnd(padding).Replace('+', '-').Replace('/', '_');
    }

    public string RandomDigits6()
        => (new Random().NextInt64() % (int)Math.Pow(10, 6)).ToString();
}
