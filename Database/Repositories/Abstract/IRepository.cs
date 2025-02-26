using Fiicode25Auth.Database.DBObjects.Abstract;

namespace Fiicode25Auth.Database.Repositories.Abstract;

/// <summary>
///     Minimal API to manipulate a collection of <c>T</c>
/// </summary>
public interface IRepository<T> where T : struct, IIdentified, ITimestamped 
{
    /// <summary>Gets an item by its Id</summary>
    /// <remarks>If no item with the <c>id</c> exists, returns null</remarks>
    T? ById(Guid id);

    IEnumerable<T> All();

    /// <summary>Commits <c>obj</c> to the collection</summary>
    /// <remarks>
    /// <para>
    ///     If <c>obj.Id</c> is <c>Guid.Empty</c>, an Id is generated
    ///     along with a creation timestamp.
    /// </para>
    /// <para>
    ///     If <c>obj.Id</c> exists, the item is UPDATED,
    ///     otherwise it is CREATED.
    /// </para>
    /// <para>
    ///     The update timestamp is always updated after a commit.
    /// </para>
    /// </remarks>
    /// <returns>The created/updated item</returns> 
    T Commit(T obj);
}
