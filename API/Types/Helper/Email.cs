using Fiicode25Auth.API.Types.Helper.Abstract;

namespace Fiicode25Auth.API.Types.Helper;

public class Email : IEmail
{
    // TODO: Add regex validation for the address
    public string Address {get; private set;}

    public bool IsVerified => VerifyToken != null;

    public string? VerifyToken {get; private set;}

    public Email(string address)
    {
        Address=address;  
        VerifyToken=_generateToken();
    }

    public Email(string address, string? token)
    {
        Address=address;
        VerifyToken=token;
    }

    private string _generateToken()
    {
        var random = new Random();
        var token = new byte[128];
        random.NextBytes(token);

        char[] padding = { '=' };
        return System.Convert.ToBase64String(token)
        .TrimEnd(padding).Replace('+', '-').Replace('/', '_');
    }
}
