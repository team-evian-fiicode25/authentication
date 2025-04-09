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

    public bool IsVerified {get; private set;}

    public string? VerifyToken {get; private set;}

    public string RequestVerification()
    {
        if (IsVerified)
            throw new GraphQLException("Cannot request verification for an already verified email");

        return VerifyToken = _tokenGenerator.Base64Url128Bytes();
    }

    public void Verify()
    {
        IsVerified = true;
        VerifyToken = null;
    }

    public bool VerifyIfMatches(string token)
    {
        if(token != VerifyToken)
            return false;

        Verify();
        return true;
    }

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
        IsVerified=false;
        _tokenGenerator=tokenGenerator;
    }

    public Email(string address, bool isVerified, string? token, ISecureTokenGenerator tokenGenerator)
    {
        _address="";
        Address=address;
        IsVerified=isVerified;
        VerifyToken=token;
        _tokenGenerator=tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}
