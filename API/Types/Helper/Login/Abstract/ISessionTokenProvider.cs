namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface ISessionTokenProvider
{
    ISessionToken New();

    ISessionToken FromDBO(Database.DBObjects.SessionToken sesionToken);
    Database.DBObjects.SessionToken ToDBO(ISessionToken token);
}

