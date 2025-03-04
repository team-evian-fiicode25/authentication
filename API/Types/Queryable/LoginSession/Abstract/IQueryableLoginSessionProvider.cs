namespace Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;

public interface IQueryableLoginSessionProvider
{
    IQueryableLoginSession FromDBO(Database.DBObjects.LoginSessionWith2FAData loginSession);
}
