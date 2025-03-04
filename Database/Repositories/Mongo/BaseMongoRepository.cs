using Fiicode25Auth.Database.DBObjects.Abstract;
using MongoDB.Driver;

namespace Fiicode25Auth.Database.Repositories.Mongo;

public abstract class BaseMongoRepository<R, W> 
    where W : class, IIdentified, ITimestamped 
    where R : class, IIdentified, ITimestamped
{

    public virtual IEnumerable<R> All()
        => _db.AsQueryable();

    public virtual async Task<R?> ById(Guid id)
        => await _db.Find(_filter.Eq(l => l.Id, id)).FirstOrDefaultAsync();

    public async Task<R?> Remove(Guid id)
    {
        var obj = await ById(id);
        if (obj == null)
            return null;

        await _db.DeleteOneAsync(_filter.Eq(l => l.Id, id));
        return obj;
    }

    protected W _stampObject(W obj)
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

    public BaseMongoRepository(IMongoCollection<R> collection)
    {
        _db=collection;
    }

    protected IMongoCollection<R> _db;

    protected FilterDefinitionBuilder<R> _filter => Builders<R>.Filter;
}
