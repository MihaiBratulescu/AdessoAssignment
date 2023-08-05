using Common;

namespace WorldCup.Domain.AggregateModels.Geo
{
    public class Country : AggregateRoot<int>
    {
        public string Name { get; }
        public string Code { get; }

#pragma warning disable CS8618
        private Country() { }
#pragma warning restore CS8618
    }
}
