using WorldCup.Domain.AggregateModels.Teams;
using WorldCup.Domain.Enumerations;
using WorldCup.Domain.ValueObjects;

namespace WorldCup.Domain.AggregateModels.Groups
{
    public class FootballCup : AggregateRoot<int>
    {
        public int Year { get; }
        public CupGroupCount GroupCount { get; }
        public PersonalName Drawer { get; }

        private List<FootballCupGroups> _groups = new ();
        public ICollection<FootballCupGroups> Groups => _groups.AsReadOnly();

        #region Constructors
#pragma warning disable CS8618
        private FootballCup() { }
#pragma warning restore CS8618
        public FootballCup(int year, CupGroupCount groups, PersonalName drawer)
        {
            Year = year;
            Drawer = drawer;
            GroupCount = groups;
        }
        #endregion

        public void AddTeam(FootballTeam team, FootballGroups group)
        {
            _groups.Add(new FootballCupGroups(team, this, group));
        }

        public void AddTeams(FootballTeam team, FootballGroups group)
        {
            _groups.Add(new FootballCupGroups(team, this, group));
        }
    }
}
