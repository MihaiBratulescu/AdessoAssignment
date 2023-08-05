using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldCup.Application.Interfaces.Logging;
using WorldCup.Application.Interfaces.Repositories.Geo;
using WorldCup.Infrastructure.Caching;
using WorldCup.Infrastructure.Database.Context;
using WorldCup.Infrastructure.Repositories;

namespace WorldCup.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CountriesRepository>();
            services.AddScoped<ICountriesRepository, InMemoryCountriesRepository>();
        }

        public static void AddLogger(this IServiceCollection services)
        {
        }

        public static void AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddSingleton<MemoryCacheProvider>();
            services.AddSingleton(c =>
                new RedisCacheProvider(
                    c.GetRequiredService<ILogger>(), "connectionString"));
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<WorldCupDbContext>(options =>
            {
                options.UseSqlServer("Data Source=localhost; " +
                    "Initial Catalog=WorldCupDb; " +
                    "Integrated Security=True; " +
                    "TrustServerCertificate=True;");
            });

            return services;
        }
    }
}
