using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class Email : IEmail
{
    // TODO: Add regex validation for the address
    public string Address {get; private set;}

    public bool IsVerified => VerifyToken == null;

    public string? VerifyToken {get; private set;}

    public string RequestVerification()
    {
        if (IsVerified)
            throw new GraphQLException("Cannot request verification for an already verified email");

        return VerifyToken = _tokenGenerator.Base64Url128Bytes();
    }

    public Email(string address, ISecureTokenGenerator tokenGenerator)
    {
        Address=address;  
        _tokenGenerator=tokenGenerator;
        VerifyToken=tokenGenerator.Base64Url128Bytes();
    }

    public Email(string address, string? token, ISecureTokenGenerator tokenGenerator)
    {
        Address=address;
        VerifyToken=token;
        _tokenGenerator=tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}
