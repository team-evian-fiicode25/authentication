namespace Fiicode25Auth.API.Types.Queryable.Abstract;

public interface IQueryableLoginProvider
{
    IQueryableLogin FromDBO(Database.DBObjects.Login login);
}

