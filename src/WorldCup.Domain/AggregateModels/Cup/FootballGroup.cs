using WorldCup.Domain.Enumerations;

namespace WorldCup.Domain.AggregateModels.Groups
{
    public class FootballGroup : Entity<FootballGroups>
    {
        public char Name { get; }

        #region Constructors
        private FootballGroup() { }
        public FootballGroup(FootballGroups group)
        {
            ID = group;
            Name = group.GetLetter();
        }
        #endregion

        public static implicit operator char(FootballGroup g) => g.ID.GetLetter();
        public static implicit operator byte(FootballGroup g) => (byte)g.ID;
        public static implicit operator FootballGroups(FootballGroup g) => g.ID;
    }
}
