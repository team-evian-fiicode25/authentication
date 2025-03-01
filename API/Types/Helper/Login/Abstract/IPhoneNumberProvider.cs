namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface IPhoneNumberProvider
{
    IPhoneNumber New(string phoneNumber);

    IPhoneNumber FromDBO(Database.DBObjects.PhoneNumber phoneNumber);
    Database.DBObjects.PhoneNumber ToDBO(IPhoneNumber phoneNumber);
}

