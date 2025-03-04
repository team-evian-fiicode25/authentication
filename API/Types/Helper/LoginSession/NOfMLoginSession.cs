using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;

namespace Fiicode25Auth.API.Types.Helper.LoginSession;

/// <summary>
/// Login session that is solved by any 2FA subset
/// of a given minimal size
/// </summary>
public class NOfMLoginSession : ILoginSession
{
    public Guid? Id {get; private set;}

    public string IdentifyingToken {get; private set;}

    public DateTime ExpiresAt {get; private set;}

    public IEmail2FA? Email {get; private set;}

    public IPhone2FA? Phone {get; private set;}

    public Guid LoginId {get; private set;}

    private int _minimumToSolve;
    public bool IsSolved { get
    {
        var solvables = new List<ISolvable?>(){Email, Phone};
        var available = solvables.Where(s => s != null);

        if(!available.Any())
            return true;

        var solvedCount = available.Where(s => s != null && s.IsSolved).Count();

        return solvedCount >= _minimumToSolve;
    }}
    
    public NOfMLoginSession(DateTime expiresAt,
                            Guid loginId,
                            ISecureTokenGenerator tokenGenerator,
                            Guid? id = null,
                            IEmail2FA? email = null,
                            IPhone2FA? phone = null,
                            int mininumToSolve = 1,
                            string? identifyingToken = null)
    {
        if (expiresAt <= DateTime.UtcNow)
        {
            throw new ArgumentException("Cannot create expired login session");
        }

        Id=id;
        IdentifyingToken=identifyingToken ?? tokenGenerator.Base64Url128Bytes();
        ExpiresAt=expiresAt;
        Email=email;
        Phone=phone;
        LoginId=loginId;
        _minimumToSolve=mininumToSolve;
    }
}
