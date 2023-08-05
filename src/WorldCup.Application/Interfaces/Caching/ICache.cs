namespace WorldCup.Application.Interfaces.Caching
{
    public interface ICache
    {
        Task<T?> Get<T>(string key);
        Task<T?> Get<T>(string key, Func<Task<T?>> fallback);
        Task Set<T>(string key, T value, TimeSpan expirationTime);
        Task Remove(string key);
    }
}
