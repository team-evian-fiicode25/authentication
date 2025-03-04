namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IQueryableSessionTokenProvider 
{
    IQueryableSessionToken FromDBO(Database.DBObjects.SessionToken sessionToken,
                                   Database.DBObjects.Login login);

    IQueryableSessionToken FromDBO(Database.DBObjects.SessionToken sessionToken,
                                   string loginId);
}
