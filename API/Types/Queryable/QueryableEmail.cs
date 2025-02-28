using Fiicode25Auth.API.Types.Helper.Abstract;
using Fiicode25Auth.API.Types.Queryable.Abstract;

namespace Fiicode25Auth.API.Types.Queryable;

public class QueryableEmail : IQueryableEmail
{
    public string Address => _email.Address;
    public bool IsVerified => _email.IsVerified;

    public QueryableEmail(IEmail email)
    {
        _email=email;
    }
    private IEmail _email;
}
