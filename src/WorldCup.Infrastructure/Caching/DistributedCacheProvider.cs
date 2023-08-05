using WorldCup.Application.Interfaces.Caching;

namespace WorldCup.Infrastructure.Caching
{
    internal class DistributedCacheProvider : ICache
    {
        public Task<T?> Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T?> Get<T>(string key, Func<Task<T?>> fallback)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string key)
        {
            throw new NotImplementedException();
        }

        public Task Set<T>(string key, T value, TimeSpan expirationTime)
        {
            throw new NotImplementedException();
        }
    }
}
