using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.AggregateModels.Teams;

namespace WorldCup.Application.Interfaces.Repositories.WorldCup
{
    public interface IWorldCupRepository:
        IWriteRepository<FootballCup, int>,
        IReadRepository<FootballCup, int>
    {
        Task<FootballCup?> GetByYearAsync(int year);
        public Task<FootballTeam[]> GetWorldCupTeamsAsync();
    }
}
