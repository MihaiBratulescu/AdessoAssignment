using Microsoft.Extensions.Caching.Memory;
using WorldCup.Application.Interfaces.Caching;

namespace WorldCup.Infrastructure.Caching
{
    internal class MemoryCacheProvider : ICache
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCacheProvider(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public Task<T?> Get<T>(string key) => ((T?)memoryCache.Get(key)).AsCompletedTask();

        public async Task<T?> Get<T>(string key, Func<Task<T?>> fallback)
        {
            return await Get<T>(key) ?? await fallback();
        }

        public Task Remove(string key)
        {
            memoryCache.Remove(key);

            return Task.CompletedTask;
        }

        public Task Set<T>(string key, T value, TimeSpan expirationTime)
        {
            memoryCache.Set(key, value, expirationTime);
            return Task.CompletedTask;
        }
    }
}
