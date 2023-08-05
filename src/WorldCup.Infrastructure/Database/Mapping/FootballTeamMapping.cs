using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldCup.Domain.AggregateModels.Geo;
using WorldCup.Domain.AggregateModels.Teams;

namespace WorldCup.Infrastructure.Database.Mapping
{
    internal class FootballTeamMapping : EntityMapping<FootballTeam, int>
    {
        public override void Configure(EntityTypeBuilder<FootballTeam> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);

            builder.HasOne<Country>()
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
