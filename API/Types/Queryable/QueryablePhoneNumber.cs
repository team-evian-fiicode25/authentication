using Fiicode25Auth.API.Types.Helper.Abstract;
using Fiicode25Auth.API.Types.Queryable.Abstract;

namespace Fiicode25Auth.API.Types.Queryable;

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


