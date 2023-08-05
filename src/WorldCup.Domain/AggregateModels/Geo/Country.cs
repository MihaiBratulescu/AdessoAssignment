using Common;
using WorldCup.Domain.AggregateModels.Teams;

namespace WorldCup.Domain.AggregateModels.Geo
{
    public class Country : AggregateRoot<int>
    {
        public string Name { get; }
        public string ISOCode { get; }

#pragma warning disable CS8618
        private Country() { }
#pragma warning restore CS8618
    }
}
