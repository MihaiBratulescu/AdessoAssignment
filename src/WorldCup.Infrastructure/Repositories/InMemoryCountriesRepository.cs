using WorldCup.Application.Interfaces.Caching;
using WorldCup.Application.Interfaces.Repositories.Geo;
using WorldCup.Domain.AggregateModels.Geo;
using WorldCup.Infrastructure.Caching;

namespace WorldCup.Infrastructure.Repositories
{
    internal class InMemoryCountriesRepository : ICountriesRepository
    {
        private readonly ICache cache;
        private readonly CountriesRepository repository;

        public InMemoryCountriesRepository(MemoryCacheProvider cache, CountriesRepository repository)
        {
            this.repository = repository;
            this.cache = cache;
        }

        public async ValueTask<Country?> FindAsync(int id)
        {
            var key = $"Country-{id}";

            return await cache.Get(key, async () =>
            {
                var stored = await repository.FindAsync(id);

                await cache.Set(key, stored, CacheDuration.Long);

                return stored;
            });
        }

        public Task<Country?> GetByCodeAsync(string code)
        {
            var key = $"Country-{code}";
            return cache.Get(key, async () =>
            {
                var stored = await repository.GetByCodeAsync(code);

                await cache.Set(key, stored, CacheDuration.Long);

                return stored;
            });
        }

        public async Task<Country[]> GetAllAsync()
        {
            const string key = "AllCountries";

            return await cache.Get(key, async () =>
            {
                var countries = await repository.GetAllAsync();

                await cache.Set(key, countries, CacheDuration.Long);

                return countries;
            });
        }

        #region Disposable
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    repository.Dispose();
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
