using Fiicode25Auth.API.Types.Value.Abstract;

namespace Fiicode25Auth.API.Types.Helper.Login.Abstract;

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
    UsernameValue? Username {get; set;}
    IPassword Password {get; set;}
    IPhoneNumber? PhoneNumber {get; set;}
    IEmail? Email {get; set;}
    ISessionTokens SessionTokens {get;}
}
