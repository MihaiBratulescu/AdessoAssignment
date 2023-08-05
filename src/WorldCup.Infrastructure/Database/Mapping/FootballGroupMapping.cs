using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.Enumerations;

namespace WorldCup.Infrastructure.Database.Mapping
{
    internal class FootballGroupMapping : EntityMapping<FootballGroup, FootballGroups>
    {
        public override void Configure(EntityTypeBuilder<FootballGroup> builder)
        {
            base.Configure(builder);

            builder.Property(g => g.ID).HasConversion<byte>();
            builder.Property(g => g.Name).IsRequired();
        }
    }
}
