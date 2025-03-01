namespace Fiicode25Auth.API.Types.Queryable.Login.Abstract;

public interface IQueryableLoginProvider
{
    IQueryableLogin FromDBO(Database.DBObjects.Login login);
}

