using Fiicode25Auth.Database.DBObjects.Abstract;
using Fiicode25Auth.Database.Repositories.Abstract;

namespace Fiicode25Auth.Database.Repositories.InMemory;

public abstract class InMemoryRepository<R, W> : IRepository<R, W> 
    where W : class, IIdentified, ITimestamped 
    where R : class
{
    protected abstract Task<R> _converter(W obj);
    protected abstract Guid _id(R obj);

    protected List<R> _store=new List<R>();

    public virtual IEnumerable<R> All()
    {
        return _store.AsReadOnly();
    }

    public virtual async Task<R?> ById(Guid id)
        => _store.FirstOrDefault(el => _id(el) == id);

    public virtual async Task<R> Commit(W obj)
    {
        obj=_sanitizeObject(obj);
        var asRead = await _converter(obj);

        var idx = _store.FindIndex(el => _id(el) == obj.Id);

        if (idx == -1)
        {
            _store.Add(asRead);
            return asRead;
        }

        _removeItemAtIndex(idx);

        _store.Add(asRead);
        return asRead;
    }

    public virtual async Task<R?> Remove(Guid id)
    {
        var idx = _store.FindIndex(el => _id(el) == id);

        if (idx == -1)
            return null;

        return _removeItemAtIndex(idx);
    }

    private R _removeItemAtIndex(int idx)
    {
        (_store[idx], _store[_store.Count-1]) 
            = (_store[_store.Count-1], _store[idx]);

        var item = _store[_store.Count-1];
        _store.RemoveAt(_store.Count-1);
        return item;
    }

    private W _sanitizeObject(W obj)
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

