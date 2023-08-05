using WorldCup.Domain.Enumerations;

namespace WorldCup.Domain.AggregateModels.Groups
{
    public class FootballCupGroups : Entity<int>
    {
        public int FootballCoupId { get; }
        public int FootballTeamId { get; }
        public FootballGroups FootballGroupId { get; }
    }
}
