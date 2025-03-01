using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login;

public class EmailProvider : IEmailProvider
{
    public IEmail NewFromAddress(string email)
        => new Email(email);

    public IEmail FromDBO(Database.DBObjects.Email email)
        => new Email(email.Address, email.VerifyToken);

    public Database.DBObjects.Email ToDBO(IEmail email) => new()
    {
        Address = email.Address,
        VerifyToken = email.VerifyToken
    };
}

