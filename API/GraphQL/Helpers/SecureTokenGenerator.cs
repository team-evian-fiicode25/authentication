using System.Security.Cryptography;

using Fiicode25Auth.API.GraphQL.Helpers.Abstract;

namespace Fiicode25Auth.API.GraphQL.Helpers;

public class SecureTokenGenerator : ISecureTokenGenerator
{
    public string Base64Url128Bytes()
    {
        var token = RandomNumberGenerator.GetBytes(128);

        char[] padding = { '=' };
        return System.Convert.ToBase64String(token)
        .TrimEnd(padding).Replace('+', '-').Replace('/', '_');
    }

    public string RandomDigits6()
    {
        const int length = 6;

        var num = RandomNumberGenerator
            .GetInt32((int)Math.Pow(10, length))
            .ToString();

        var paddingSize = Math.Max(0, length - num.Length);

        var padding = string.Join("", Enumerable.Repeat("0", paddingSize));

        return padding + num;
    }
}
