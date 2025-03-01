using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.Database.Repositories.Abstract;

public interface ILoginSessionRepository : IRepository<LoginSession> {
    Task<LoginSessionWith2FAData> Get(string token);
}
