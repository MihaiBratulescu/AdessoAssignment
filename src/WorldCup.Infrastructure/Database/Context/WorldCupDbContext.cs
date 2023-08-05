using Microsoft.EntityFrameworkCore;
using WorldCup.Domain.AggregateModels.Geo;
using WorldCup.Domain.AggregateModels.Teams;

namespace WorldCup.Infrastructure.Database.Context
{
    internal class WorldCupDbContext : DbContext
    {
        public DbSet<Country> Countries { get; private set; } = null!;
        public DbSet<FootballTeam> FootballTeams { get; private set; } = null!;

        public WorldCupDbContext(DbContextOptions options) : base(options)
        {
            //for development only
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
