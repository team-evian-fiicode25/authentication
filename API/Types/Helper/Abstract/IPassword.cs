namespace Fiicode25Auth.API.Types.Helper.Abstract;

public interface IPassword
{
    string Hash {get;}
    
    /// <returns>true if <c>password</c> mathches the stored hash and false otherwise</returns>
    bool Verify(string password);
}
