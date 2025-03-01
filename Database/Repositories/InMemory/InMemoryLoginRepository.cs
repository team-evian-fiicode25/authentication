using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Exceptions;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryLoginRepository : InMemoryRepository<Login>, ILoginRepository
{
    public async Task<Login?> ByUsername(string username)
    {
        var filtered = _store.Where(l => l.UserName == username);
        if (filtered.Count() == 0)
            return null;

        return filtered.First();
    }

    public async Task<Login?> ByPhoneNumber(string phoneNumber)
        => _store.FirstOrDefault(l => l.PhoneNumber?.Number == phoneNumber);

    public async Task<Login?> ByEmail(string email)
        => _store.FirstOrDefault(l => l.Email?.Address == email);

    public async Task<Login?> BySessionToken(string token)
        => _store.FirstOrDefault(
                l => _filterExiredSessions(l)
                        .SessionTokens
                        .Any(st => st.Token == token));

    public async override Task<Login> Commit(Login obj)
    {
        if(obj.UserName != null) 
        {
            var login = await ByUsername(obj.UserName);
            if(login != null && login?.Id != obj.Id)
            {
                throw new DuplicateUsernameException();
            }
        }

        return await base.Commit(_filterExiredSessions(obj));
    }

    public override IEnumerable<Login> All()
    {
        return base.All().Select(l => _filterExiredSessions(l));
    }

    public async override Task<Login?> ById(Guid id)
    {
        var l = await base.ById(id);
        if(l == null)
            return null;

        return _filterExiredSessions(l);
    }

    public async override Task<Login?> Remove(Guid id)
    {
        var l = await base.Remove(id);
        if(l == null)
            return null;

        return _filterExiredSessions(l);
    }

    private Login _filterExiredSessions(Login login)
    {
        login.SessionTokens = login.SessionTokens
            .Where(st => st.Expiration > DateTime.UtcNow)
            .ToList();

        return login;
    }
}
