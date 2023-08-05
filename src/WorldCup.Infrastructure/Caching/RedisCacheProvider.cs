using StackExchange.Redis;
using System.Text.Json;
using WorldCup.Application.Interfaces.Caching;
using WorldCup.Application.Interfaces.Logging;

namespace WorldCup.Infrastructure.Caching
{
    internal class RedisCacheProvider : ICache
    {
        private readonly ILogger logger;
        private readonly ConnectionMultiplexer connectionMultiplexer;
        private readonly ShortCircuit<RedisValue> circuit = new ShortCircuit<RedisValue>();

        public RedisCacheProvider(ILogger logger, string connectionString)
        {
            connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            this.logger = logger;
        }

        public async Task<T?> Get<T>(string key, Func<Task<T?>> fallBack)
        {
            return await Get<T>(key) ?? await fallBack();
        }

        public Task Set<T>(string key, T value, TimeSpan expirationTime)
        {
            return UpdateDatabase(database =>
                database.StringSetAsync(key, JsonSerializer.Serialize(value), expirationTime));
        }

        public Task Remove(string key)
        {
            return UpdateDatabase(database =>
                database.KeyDeleteAsync(key));
        }

        private async Task<T?> Get<T>(string key)
        {
            var value = await RetrieveData(database => database.StringGetAsync(key));

            if (value.HasValue)
#pragma warning disable CS8604
                return JsonSerializer.Deserialize<T>(value);
#pragma warning restore CS8604

            return default;
        }

        private async Task UpdateDatabase(Func<IDatabase, Task> update)
        {
            try
            {
                await circuit.PassCircuit(async () => await update(await GetDatabase()));
            }
            catch (Exception e)
            {
                circuit.CutCircuit();
                await logger.LogException(e, "Error accessing Redis.");
                //send notification
            }
        }

        private async Task<RedisValue> RetrieveData(Func<IDatabase, Task<RedisValue>> retrieve)
        {
            try
            {
                return await circuit.PassCircuit(async () =>
                        await retrieve(await GetDatabase()),
                        RedisValue.EmptyString);
            }
            catch (Exception e)
            {
                circuit.CutCircuit();
                await logger.LogException(e, "Error accessing Redis.");
                //send notification

                return RedisValue.EmptyString;
            }
        }

        private async Task<IDatabase> GetDatabase()
        {
            var database = connectionMultiplexer.GetDatabase();
            if (database == null)
            {
                circuit.CutCircuit();
                await logger.LogException("Could not access Redis database.");
                //send notification
            }

            return database;
        }
    }
}
