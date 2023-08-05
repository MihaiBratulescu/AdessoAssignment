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

            builder.HasOne(x => x.Cup)
                .WithMany()
                .HasForeignKey(x => x.CoupId);

            builder.HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            builder.HasOne(x => x.Team)
                .WithMany()
                .HasForeignKey(x => x.TeamId);

            builder.Navigation(s => s.Cup).AutoInclude();
            builder.Navigation(s => s.Group).AutoInclude();
            builder.Navigation(s => s.Team).AutoInclude();
        }
    }
}
