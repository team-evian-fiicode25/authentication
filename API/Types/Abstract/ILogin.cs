namespace Fiicode25Auth.API.Types.Abstract;

/// <summary>
///     High level representation of an account <br/>
///     Ment to serve as a helper to ensure data corectness
///     and facilitate saving to the database
/// </summary>
public interface ILogin
{
    /// <value>Id of the login if it exists in the Database</value>
    /// <remarks>
    ///     A null Id means either that the object awaits being commited
    ///     to the database, or, otherwise, it could be ment as a
    ///     throw-away temporary representation of a login
    /// </remarks>
    Guid? Id {get;} 
    string Username {get;}
    string PasswordHash {get;}

    string SetPassword(string password);

    /// <returns>true if <c>password</c> mathches the stored hash and false otherwise</returns>
    bool VerifyPassword(string password);
}
