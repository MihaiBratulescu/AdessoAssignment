using Microsoft.EntityFrameworkCore;
using WorldCup.Application.Interfaces.Repositories.WorldCup;
using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.AggregateModels.Teams;
using WorldCup.Infrastructure.Database.Context;

namespace WorldCup.Infrastructure.Repositories
{
    internal class WorldCupRepository : Repository<WorldCupDbContext, FootballCup, int>, IWorldCupRepository
    {
        public WorldCupRepository(WorldCupDbContext ctx) : base(ctx)
        {
        }

        public Task<FootballCup?> GetByYearAsync(int year)
        {
            return context.FootballCups
                .AsNoTracking()
                .Include(c => c.Groups)
                .Where(c => c.Year == year)
                .SingleOrDefaultAsync();
        }

        public Task<FootballTeam[]> GetWorldCupTeamsAsync()
        {
            return context.FootballTeams
                .ToArrayAsync();
        }
    }
}
