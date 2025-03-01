using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Exceptions;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryLoginSessionRepository : InMemoryRepository<LoginSession>, ILoginSessionRepository
{
    public override IEnumerable<LoginSession> All()
        => base.All().Where(ls => ls.Expiration > DateTime.UtcNow);

    public async Task<LoginSessionWith2FAData> Get(string token)
    {
        var loginSession = _store.Find(ls => ls.SecureIdentifier == token);
        var login = await _loginRepository.ById(loginSession.LoginId);
        if (!login.HasValue)
            throw new DanglingReferenceException("No Login found for the LoginSession");

        return new()
        {
            Email=login.Value.Email,
            PhoneNumber=login.Value.PhoneNumber,
            LoginSession=loginSession
        };
    }

    public InMemoryLoginSessionRepository(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }
    private ILoginRepository _loginRepository;
}
