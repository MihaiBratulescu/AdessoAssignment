using WorldCup.Domain.AggregateModels.Teams;
using WorldCup.Domain.Enumerations;

namespace WorldCup.Domain.AggregateModels.Groups
{
    public class FootballCupGroups
    {
        public int TeamId { get; }
        public FootballTeam? Team { get; }

        public int CoupId { get; }
        public FootballCup? Cup { get; }

        public FootballGroups GroupId { get; }
        public FootballGroup? Group { get; }

        private FootballCupGroups() { }
        public FootballCupGroups(FootballTeam team, FootballCup cup, FootballGroups group)
        {
            Team = team;
            Cup = cup;
            GroupId = group;
        }
    }
}
