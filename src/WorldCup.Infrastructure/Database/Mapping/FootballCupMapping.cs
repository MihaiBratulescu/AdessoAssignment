using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Infrastructure.Database.Mapping.OwnedNavigations;

namespace WorldCup.Infrastructure.Database.Mapping
{
    internal class FootballCupMapping : EntityMapping<FootballCup, int>
    {
        public override void Configure(EntityTypeBuilder<FootballCup> builder)
        {
            base.Configure(builder);

            builder.ConfigurePersonalName(g => g.Drawer);

            builder.Property(c => c.GroupCount).HasConversion<byte>();
        }
    }
}
