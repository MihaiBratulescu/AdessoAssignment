using Microsoft.EntityFrameworkCore;

namespace WorldCup.Infrastructure.Database.Context
{
    internal class WorldCupDbContext : DbContext
    {
        protected WorldCupDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
