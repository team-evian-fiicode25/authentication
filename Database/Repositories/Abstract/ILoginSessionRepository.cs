using Fiicode25Auth.Database.DBObjects;

namespace Fiicode25Auth.Database.Repositories.Abstract;

public interface ILoginSessionRepository : IRepository<LoginSessionWith2FAData, LoginSession> {
    Task<LoginSessionWith2FAData?> ByToken(string token);
}
