using Fiicode25Auth.Database.DBObjects.Abstract;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryRepository<T> : IRepository<T> where T : IIdentified, ITimestamped
{
    protected List<T> _store=new List<T>();

    public IEnumerable<T> All()
        => _store.AsReadOnly();

    public T? ById(Guid id)
        => _store.FirstOrDefault(el => el.Id == id);

    public void Commit(T obj)
    {
        var idx = _store.FindIndex(el => el.Id == obj.Id);

        if (idx == -1)
        {
            _store.Append(obj);
            return;
        }

        // Remove old item at O(1)
        (_store[idx], _store[_store.Count-1]) 
            = (_store[_store.Count-1], _store[idx]);
        _store.RemoveAt(_store.Count-1);

        _store.Append(obj);
    }
}

