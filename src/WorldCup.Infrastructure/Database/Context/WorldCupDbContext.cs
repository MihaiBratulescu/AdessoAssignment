using Microsoft.EntityFrameworkCore;
using WorldCup.Domain.AggregateModels.Geo;

namespace WorldCup.Infrastructure.Database.Context
{
    internal class WorldCupDbContext : DbContext
    {
        public DbSet<Country> Countries { get; private set; } = null!;

        public WorldCupDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
