namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IPhoneVerificationDTOProvider
{
    IPhoneVerificationDTO FromDBO(Fiicode25Auth.Database.DBObjects.Login login);
}

