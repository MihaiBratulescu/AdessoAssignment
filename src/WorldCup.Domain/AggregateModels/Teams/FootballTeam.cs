namespace WorldCup.Domain.AggregateModels.Teams
{
    public class FootballTeam : AggregateRoot<int>
    {
        public string Name { get; }
        public int CountryId { get; }

        #region Constructors
#pragma warning disable CS8618
        private FootballTeam() { }
#pragma warning restore CS8618
        public FootballTeam(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }
        public FootballTeam(int id, string name, int countryId)
        {
            ID = id;//for seed
            Name = name;
            CountryId = countryId;
        }
        #endregion
    }
}
