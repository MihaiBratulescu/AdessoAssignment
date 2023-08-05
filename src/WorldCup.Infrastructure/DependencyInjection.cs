using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using WorldCup.Application.Interfaces.Logging;
using WorldCup.Application.Interfaces.Repositories;
using WorldCup.Application.Interfaces.Repositories.Geo;
using WorldCup.Application.Interfaces.Repositories.WorldCup;
using WorldCup.Infrastructure.Caching;
using WorldCup.Infrastructure.Database;
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

            services.AddScoped<IWorldCupRepository, WorldCupRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
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

        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<WorldCupDbContext>(options =>
            {
                options.UseSqlServer("Data Source=localhost; " +
                    "Initial Catalog=WorldCupDb; " +
                    "Integrated Security=True; " +
                    "TrustServerCertificate=True;");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        #region CQRS
        public static void AddHandler(this IServiceCollection services)
        {
            var assemblyTypes = GetAssemblyTypes();

            var requests = assemblyTypes.Where(type => ImplementsType(type, typeof(IQuery<>), typeof(ICommand)));
            var handlers = assemblyTypes.Where(type => ImplementsType(type, typeof(IQueryHandler<,>), typeof(ICommandHandler<>))).ToArray();

            var pairs = requests.Join(handlers, q => q, GetInterfaceArgument, (q, h) => KeyValuePair.Create(q, h));

            services.Add(handlers.Select(h => new ServiceDescriptor(h, h, ServiceLifetime.Scoped)));
            services.AddScoped<IHandler>(p => new Handler(p.GetRequiredService, new Dictionary<Type, Type>(pairs)));
        }

        private static Type GetInterfaceArgument(Type type)
        {
            return (type.GetInterface("IQueryHandler`2")
                ?? type.GetInterface("ICommandHandler`1"))
                !.GetGenericArguments()[0];
        }

        private static bool ImplementsType(Type type, params Type[] typesToMatch)
        {
            return type.GetInterfaces()
                .Select(i => i.IsGenericType ? i.GetGenericTypeDefinition() : i)
                .Any(i => typesToMatch.Contains(i));
        }

        private static Type[] GetAssemblyTypes()
        {
            return Assembly
                .GetEntryAssembly()
                !.GetReferencedAssemblies()
                .Select(a => Assembly.Load(a))
                .Append(Assembly.GetEntryAssembly())
                .SelectMany(a => a!.ExportedTypes)
                .Where(type => !type.IsInterface && !type.IsAbstract)
                .ToArray();
        }
        #endregion
    }
}
