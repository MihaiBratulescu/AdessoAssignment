using WorldCup.Domain.AggregateModels.Teams;

namespace WorldCup.Application.Interfaces.Repositories.WorldCup
{
    public interface ITeamsRepository : IReadRepository<FootballTeam, int>
    {
    }
}
