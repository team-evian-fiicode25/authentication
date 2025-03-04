using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class QueryablePhoneNumber : IQueryablePhoneNumber
{
    public string Number => _phoneNumber.Number;
    public bool IsVerified => _phoneNumber.IsVerified;

    public QueryablePhoneNumber(IPhoneNumber phoneNumber)
    {
        _phoneNumber=phoneNumber;
    }
    private IPhoneNumber _phoneNumber;
}


