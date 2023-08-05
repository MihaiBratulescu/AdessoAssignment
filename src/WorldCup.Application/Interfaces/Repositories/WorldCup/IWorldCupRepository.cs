using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.AggregateModels.Teams;

namespace WorldCup.Application.Interfaces.Repositories.WorldCup
{
    public interface IWorldCupRepository:
        IWriteRepository<FootballCup, int>,
        IReadRepository<FootballCup, int>
    {
        public Task<FootballTeam[]> GetWorldCupTeamsAsync();
    }
}
