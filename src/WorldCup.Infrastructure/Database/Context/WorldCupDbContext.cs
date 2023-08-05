using Microsoft.EntityFrameworkCore;
using WorldCup.Domain.AggregateModels.Geo;
using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.AggregateModels.Teams;
using WorldCup.Domain.Enumerations;

namespace WorldCup.Infrastructure.Database.Context
{
    internal class WorldCupDbContext : DbContext
    {
        public DbSet<Country> Countries { get; private set; } = null!;
        public DbSet<FootballTeam> FootballTeams { get; private set; } = null!;

        public DbSet<FootballCup> FootballCups { get; } = null!;
        public DbSet<FootballGroup> Groups { get; } = null!;
        public DbSet<FootballCupGroups> CupGroups { get; } = null!;

        public WorldCupDbContext(DbContextOptions options) : base(options)
        {
            Seed();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<FootballGroup>()
                .HasData(Enum
                    .GetValues<FootballGroups>()
                    .Select(g => new FootballGroup(g))
                );
        }

        private void Seed()
        {
            //for development only
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Database.ExecuteSqlRaw("SET IDENTITY_INSERT Countries ON " +
                "INSERT INTO Countries (CountryId, Name, ISOCode) VALUES " +
                "(1, 'Germany', 'GER'), (2, 'Turkey', 'Tur'), (3, 'France', 'FRA'), (4, 'Netherlands', 'NED'), (5, 'Portugal', 'POR'),(6, 'Italy', 'ITA'),(7, 'Spain', 'SPA'),(8, 'Belgium', 'BEL');" +
                "SET IDENTITY_INSERT Countries OFF"
                );

            Database.ExecuteSqlRaw("INSERT INTO FootballTeams ([Name], CountryId) VALUES " +
                "('Adesso Berlin', 1),('Adesso Frankfurt', 1),('Adesso Münih', 1),('Adesso Dortmund', 1)," +
                "('Adesso Berlin', 2),('Adesso İstanbul', 2),('Adesso İzmir', 2),('Adesso Antalya', 2)," +
                "('Adesso Paris', 3),('Adesso Marsilya', 3),('Adesso Nice', 3),('Adesso Lyon', 3)," +
                "('Adesso Amsterdam', 4),('Adesso Rotterdam', 4),('Adesso Lahey', 4),('Adesso Eindhoven', 4)," +
                "('Adesso Lisbon', 5),('Adesso Porto', 5),('Adesso Braga', 5),('Adesso Coimbra', 5)," +
                "('Adesso Roma', 6),('Adesso Milano', 6),('Adesso Venedik', 6),('Adesso Napoli', 6)," +
                "('Adesso Sevilla', 7),('Adesso Madrid', 7),('Adesso Barselona', 7),('Adesso Granada', 7)," +
                "('Adesso Brüksel', 8),('Adesso Brugge', 8),('Adesso Gent', 8),('Adesso Anvers', 8);"
                );
        }
    }
}
