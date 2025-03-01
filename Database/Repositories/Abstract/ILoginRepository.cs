using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.Database.Repositories.Abstract;

public interface ILoginRepository : IRepository<Login>
{
    Task<Login?> ByUsername(string username);
    Task<Login?> ByEmail(string email);
    Task<Login?> ByPhoneNumber(string phoneNumber);
}
