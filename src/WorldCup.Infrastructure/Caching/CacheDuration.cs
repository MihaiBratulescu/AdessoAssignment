namespace WorldCup.Infrastructure.Caching
{
    internal static class CacheDuration
    {
        public static TimeSpan Short { get; } = TimeSpan.FromMinutes(1);
        public static TimeSpan Medium { get; } = TimeSpan.FromHours(1);
        public static TimeSpan Long { get; } = TimeSpan.FromDays(1);
    }
}
