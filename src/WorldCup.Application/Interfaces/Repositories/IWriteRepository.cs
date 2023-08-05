using Common;

namespace WorldCup.Application.Interfaces.Repositories
{
    public interface IWriteRepository<TEntity, TKey> : IDisposable
        where TKey : notnull
        where TEntity : AggregateRoot<TKey>
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        Task RemoveAsync(TKey id);
        void Remove(TEntity entity);
    }
}
