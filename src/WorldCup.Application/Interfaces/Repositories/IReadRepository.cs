using Common;

namespace WorldCup.Application.Interfaces.Repositories
{
    public interface IReadRepository<TEntity, TKey> : IDisposable
        where TKey : notnull
        where TEntity : AggregateRoot<TKey>
    {
        ValueTask<TEntity?> FindAsync(TKey id);
    }
}
