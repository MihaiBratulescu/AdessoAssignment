using Microsoft.EntityFrameworkCore;
using WorldCup.Application.Interfaces.Repositories.WorldCup;
using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.AggregateModels.Teams;
using WorldCup.Infrastructure.Caching;
using WorldCup.Infrastructure.Database.Context;

namespace WorldCup.Infrastructure.Repositories
{
    internal class WorldCupRepository : Repository<WorldCupDbContext, FootballCup, int>, IWorldCupRepository
    {
        private readonly RedisCacheProvider cache;

        public WorldCupRepository(RedisCacheProvider cache, WorldCupDbContext ctx) : base(ctx)
        {
            this.cache = cache;
        }

        public Task<FootballCup?> GetByYearAsync(int year)
        {
            string key = $"WorldCup-{year}";

            return cache.Get(key, async () =>
            {
                var cup = await context.FootballCups
                    .AsNoTracking()
                    .Include(c => c.Groups)
                    .Where(c => c.Year == year)
                    .SingleOrDefaultAsync();

                await cache.Set(key, cup, CacheDuration.Long);

                return cup;
            });
        }

        public Task<FootballTeam[]> GetWorldCupTeamsAsync()
        {
            return context.FootballTeams.ToArrayAsync();
        }
    }
}
