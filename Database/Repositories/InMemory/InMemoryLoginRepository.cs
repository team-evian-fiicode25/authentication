using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryLoginRepository : InMemoryRepository<Login>, ILoginRepository
{}
