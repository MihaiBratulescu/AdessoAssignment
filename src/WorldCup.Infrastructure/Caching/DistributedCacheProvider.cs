using StackExchange.Redis;
using System.Text.Json;
using WorldCup.Application.Interfaces.Caching;

namespace WorldCup.Infrastructure.Caching
{
    internal class DistributedCacheProvider : ICache
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public DistributedCacheProvider(string connectionString)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }

        public async Task<T?> Get<T>(string key, Func<Task<T?>> fallBack)
        {
            var cachedValue = await Get<T>(key);
            if (cachedValue != null)
                return cachedValue;

            var fallBackValue = await fallBack();
            if (fallBackValue != null)
                await Set(key, fallBackValue, TimeSpan.FromMinutes(10)); // Set a default fallback expiration time (10 minutes)

            return fallBackValue;
        }

        public async Task Set<T>(string key, T value, TimeSpan expirationTime)
        {
            var database = _connectionMultiplexer.GetDatabase();
            await database.StringSetAsync(key, JsonSerializer.Serialize(value), expirationTime);
        }

        public async Task Remove(string key)
        {
            var database = _connectionMultiplexer.GetDatabase();
            await database.KeyDeleteAsync(key);
        }

        private async Task<T?> Get<T>(string key)
        {
            var database = _connectionMultiplexer.GetDatabase();
            var value = await database.StringGetAsync(key);

            if (value.HasValue)
                return JsonSerializer.Deserialize<T>(value);

            return default;
        }
    }
}
