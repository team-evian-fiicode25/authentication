namespace Fiicode25Auth.API.Types.Queryable.Abstract;

/// <summary>
///     Query interface for the GraphQL API
/// </summary>
public interface IQueryableLogin
{
    string Id {get;}
    string? Username {get;}
    bool VerifyPassword(string password);

    IQueryableEmail? Email {get;}
    IQueryablePhoneNumber? PhoneNumber {get;}

    string CreatedAt {get;}
    string UpdatedAt {get;}
}
