using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Exceptions;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryLoginSessionRepository : InMemoryRepository<LoginSessionWith2FAData, LoginSession>, ILoginSessionRepository
{
    public override IEnumerable<LoginSessionWith2FAData> All()
        => base.All().Where(ls => ls.LoginSession.Expiration > DateTime.UtcNow);

    public async Task<LoginSessionWith2FAData?> ByToken(string token)
        => _store.FirstOrDefault(ls => ls.LoginSession.SecureIdentifier == token);


    protected async override Task<LoginSessionWith2FAData> _converter(LoginSession obj)
    {
        var login = await _loginRepository.ById(obj.LoginId);
        if (login == null)
            throw new DanglingReferenceException("No Login found for the LoginSession");

        return new()
        {
            Email=login.Email,
            PhoneNumber=login.PhoneNumber,
            LoginSession=obj,
        };
    }


    protected override Guid _id(LoginSessionWith2FAData obj)
        => obj.LoginSession.Id;

    public InMemoryLoginSessionRepository(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }
    private ILoginRepository _loginRepository;
}
