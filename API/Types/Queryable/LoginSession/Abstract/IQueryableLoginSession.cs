using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;

public interface IQueryableLoginSession
{
    string Id {get;}
    string IdentifyingToken {get;}

    int TimeLeftSeconds {get;}

    List<TwoFactorMean> Available2FAOptions {get;}
    List<TwoFactorMean> Solved2FAOptions {get;}

    string LoginId {get;}
    Task<IQueryableLogin> Login {get;}

    bool IsSolved {get;}

    Task<IQueryableSessionToken?> SessionToken {get;}

    string CreatedAt {get;}
    string UpdatedAt {get;}
}

public enum TwoFactorMean
{
    Email,
    Phone
}
