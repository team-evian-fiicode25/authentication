using Fiicode25Auth.Database.DBObjects.Abstract;

namespace Fiicode25Auth.Database.Repositories.Abstract;

public interface IRepository<T> where T : struct, IIdentified, ITimestamped 
{
    T? ById(Guid id);
    IEnumerable<T> All();
    void Commit(T obj);
}
