using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Exceptions;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryLoginRepository : InMemoryRepository<Login>, ILoginRepository
{
    public async Task<Login?> ByUsername(string username)
        => _store.FirstOrDefault(l => l.UserName == username);

    public async Task<Login?> ByPhoneNumber(string phoneNumber)
        => _store.FirstOrDefault(l => l.PhoneNumber?.Number == phoneNumber);

    public async Task<Login?> ByEmail(string email)
        => _store.FirstOrDefault(l => l.Email?.Address == email);

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
