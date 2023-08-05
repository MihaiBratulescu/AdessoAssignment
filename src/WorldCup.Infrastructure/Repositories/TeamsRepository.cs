using Microsoft.EntityFrameworkCore;
using WorldCup.Application.Interfaces.Repositories.WorldCup;
using WorldCup.Domain.AggregateModels.Teams;
using WorldCup.Infrastructure.Database.Context;

namespace WorldCup.Infrastructure.Repositories
{
    internal class TeamsRepository : Repository<WorldCupDbContext, FootballTeam, int>, ITeamsRepository
    {
        public TeamsRepository(WorldCupDbContext ctx) : base(ctx)
        {
        }
    }
}
