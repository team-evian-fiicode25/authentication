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

        return await base.Commit(obj);
    }
}
