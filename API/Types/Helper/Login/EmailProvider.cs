using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class EmailProvider : IEmailProvider
{
    public IEmail NewFromAddress(string email)
        => new Email(email, _tokenGenerator);

    public IEmail FromDBO(Database.DBObjects.Email email)
        => new Email(email.Address, email.VerifyToken, _tokenGenerator);

    public Database.DBObjects.Email ToDBO(IEmail email) => new()
    {
        Address = email.Address,
        VerifyToken = email.VerifyToken
    };

    public EmailProvider(ISecureTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    private ISecureTokenGenerator _tokenGenerator;
}

