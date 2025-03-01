namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface ILoginProvider
{
    ILogin NewWithPassword(string password);

    ILogin FromDBO(Database.DBObjects.Login login);
    Database.DBObjects.Login ToDBO(ILogin login);
}
