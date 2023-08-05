using WorldCup.Domain.Enumerations;

namespace WorldCup.Domain.AggregateModels.Groups
{
    public class FootballCupGroups
    {
        public int TeamId { get; }
        public int CoupId { get; }
        public FootballGroups GroupId { get; }
    }
}
