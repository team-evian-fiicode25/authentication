namespace Fiicode25Auth.API.Types.Helper.Abstract;

public interface IEmailProvider
{
    IEmail NewFromAddress(string email);

    IEmail FromDBO(Database.DBObjects.Email email);
    Database.DBObjects.Email ToDBO(IEmail email);
}

