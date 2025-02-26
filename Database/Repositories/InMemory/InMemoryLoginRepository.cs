using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryLoginRepository : InMemoryRepository<Login>, ILoginRepository
{
    public async Task<Login?> ByUsername(string username)
        => _store.FirstOrDefault(l => l.UserName == username);

    public async override Task<Login> Commit(Login obj)
    {
        var login = await ByUsername(obj.UserName);
        if(login != null && login?.Id != obj.Id)
        {
            throw new ArgumentException("Duplicate username error");
        }

        return await base.Commit(obj);
    }
}
