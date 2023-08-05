using Microsoft.EntityFrameworkCore;
using WorldCup.Application.Interfaces.Repositories;

namespace WorldCup.Infrastructure.Repositories
{
    internal class Repository<TContext, TEntity, TKey> : IReadRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey>
        where TKey : notnull
        where TContext : DbContext
        where TEntity : AggregateRoot<TKey>
    {
        protected readonly TContext context;

        protected Repository(TContext ctx)
        {
            context = ctx;
        }

        public virtual async Task AddAsync(TEntity entity) => await Entities()
            .AddAsync(entity);

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities) => Entities()
            .AddRangeAsync(entities);

        public virtual ValueTask<TEntity?> FindAsync(TKey id) => Entities().FindAsync(id);

        public virtual void Update(TEntity entity) => context.Update(entity);

        public virtual async Task RemoveAsync(TKey id)
        {
            var entity = await FindAsync(id);

            if (entity != null)
            {
                Entities().Remove(entity);
            }
        }

        public virtual void Remove(TEntity entity) => Entities().Remove(entity);

        protected DbSet<TEntity> Entities() => context.Set<TEntity>();

        #region Dispose
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
