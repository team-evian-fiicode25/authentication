namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

public interface IPasswordProvider
{
    IPassword New(string password);
    IPassword FromHash(string passwordHash);
}

