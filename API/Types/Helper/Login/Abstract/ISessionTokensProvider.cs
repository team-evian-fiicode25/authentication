namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface ISessionTokensProvider
{
    ISessionTokens New();

    ISessionTokens FromDBO(List<Database.DBObjects.SessionToken> sessionTokens);
    List<Database.DBObjects.SessionToken> ToDBO(ISessionTokens sessionTokens);
}

