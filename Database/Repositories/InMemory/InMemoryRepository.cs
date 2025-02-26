using Fiicode25Auth.Database.DBObjects.Abstract;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public class InMemoryRepository<T> : IRepository<T> where T : struct, IIdentified, ITimestamped
{
    protected List<T> _store=new List<T>();

    public IEnumerable<T> All()
    {
        return _store.AsReadOnly();
    }

    public async Task<T?> ById(Guid id)
        => _store.FirstOrDefault(el => el.Id == id);

    public virtual async Task<T> Commit(T obj)
    {
        obj=_sanitizeObject(obj);

        var idx = _store.FindIndex(el => el.Id == obj.Id);

        if (idx == -1)
        {
            _store.Add(obj);
            return obj;
        }

        // Remove old item at O(1)
        (_store[idx], _store[_store.Count-1]) 
            = (_store[_store.Count-1], _store[idx]);
        _store.RemoveAt(_store.Count-1);

        _store.Add(obj);
        return obj;
    }

    private T _sanitizeObject(T obj)
    {
        if (obj.Id == Guid.Empty)
        {
            obj.Id = Guid.NewGuid();
            obj.UpdatedAt = obj.CreatedAt = DateTime.UtcNow;
            return obj;
        }

        obj.UpdatedAt = DateTime.UtcNow;
        return obj;
    }
}

