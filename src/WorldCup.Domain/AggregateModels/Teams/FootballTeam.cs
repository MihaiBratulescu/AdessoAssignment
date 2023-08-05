namespace WorldCup.Domain.AggregateModels.Teams
{
    public class FootballTeam : AggregateRoot<int>
    {
        public string Name { get; }
        public int CountryId { get; }

        private FootballTeam() { }
        public FootballTeam(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }
    }
}
