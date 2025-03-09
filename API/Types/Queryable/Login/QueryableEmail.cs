using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class QueryableEmail : IQueryableEmail
{
    public string Address => _email.Address;
    public bool IsVerified => _email.IsVerified;
    public string? VerifyToken => _email.VerifyToken;

    public QueryableEmail(IEmail email)
    {
        _email=email;
    }
    private IEmail _email;
}
