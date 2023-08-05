using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.AggregateModels.Teams;

namespace WorldCup.Infrastructure.Database.Mapping
{
    internal class FootballCupGroupsMapping : IEntityTypeConfiguration<FootballCupGroups>
    {
        public void Configure(EntityTypeBuilder<FootballCupGroups> builder)
        {
            builder.HasKey(j => new { j.CoupId, j.GroupId, j.TeamId });
            builder.HasIndex(x => new { x.CoupId, x.TeamId }).IsUnique();

            builder.HasOne<FootballCup>()
                .WithMany()
                .HasForeignKey(x => x.CoupId);

            builder.HasOne<FootballGroup>()
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            builder.HasOne<FootballTeam>()
                .WithMany()
                .HasForeignKey(x => x.TeamId);
        }
    }
}
