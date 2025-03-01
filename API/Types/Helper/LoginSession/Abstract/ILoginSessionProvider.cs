using Fiicode25Auth.API.Types.Helper.Login.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

public interface ILoginSessionProvider
{
    ILoginSession New(ILogin login);

    ILoginSession FromDBO(Database.DBObjects.LoginSessionWith2FAData loginSession);
    Database.DBObjects.LoginSession ToDBO(ILoginSession loginSession);
}

