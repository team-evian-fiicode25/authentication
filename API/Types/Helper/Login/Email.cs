using System.Text.RegularExpressions;
using Fiicode25Auth.API.Exceptions;
using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class Email : IEmail
{
    private string _address;
    public string Address 
    {
        get { return _address; }
        private set 
        {
            _address = _validateEmail(value);
        }
    }

    public bool IsVerified => VerifyToken == null;

    public string? VerifyToken {get; private set;}

    private string _validateEmail(string email)
    {
        if(!Regex.IsMatch(email, """^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$"""))
            throw new EmailFormatException();
        return email;
    }

    public Email(string address, ISecureTokenGenerator tokenGenerator)
    {
        _address="";
        Address=address;  
        VerifyToken=tokenGenerator.Base64Url128Bytes();
    }

    public Email(string address, string? token)
    {
        _address="";
        Address=address;
        VerifyToken=token;
    }

}
