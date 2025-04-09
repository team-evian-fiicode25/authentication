namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IEmailVerificationDTOProvider
{
    IEmailVerificationDTO FromDBO(Database.DBObjects.Login login);
}

