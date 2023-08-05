namespace WorldCup.Domain.AggregateModels.Geo
{
    public class Country : AggregateRoot<int>
    {
        public string Name { get; }
        public string ISOCode { get; }

#pragma warning disable CS8618
        private Country() { }
#pragma warning restore CS8618
        public Country(string name, string code)
        {
            Name = name;
            ISOCode = code;
        }

        public Country(int id, string name, string code)
        {
            ID = id;//for seed
            Name = name;
            ISOCode = code;
        }
    }
}
