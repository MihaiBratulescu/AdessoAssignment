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

        public DbSet<FootballCup> Cups { get; } = null!;
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
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Database.ExecuteSqlRaw("SET IDENTITY_INSERT Countries ON " +
                "INSERT INTO Countries (CountryId, Name, ISOCode) VALUES " +
                "(1, 'Germany', 'GER'), (2, 'Turkey', 'Tur'), (3, 'France', 'FRA'), (4, 'Netherlands', 'NED'), (5, 'Portugal', 'POR'),(6, 'Italy', 'ITA'),(7, 'Spain', 'SPA'),(8, 'Belgium', 'BEL');" +
                "SET IDENTITY_INSERT Countries OFF");

            Database.ExecuteSqlRaw("SET IDENTITY_INSERT FootballTeams ON " +
                "INSERT INTO FootballTeams (FootballTeamId, [Name], CountryId) VALUES " +
                "(1, 'Adesso Berlin', 1),(2, 'Adesso Frankfurt', 1),(3, 'Adesso Münih', 1),(4, 'Adesso Dortmund', 1)," +
                "(5, 'Adesso Berlin', 2),(6, 'Adesso İstanbul', 2),(7, 'Adesso İzmir', 2),(8, 'Adesso Antalya', 2)," +
                "(9, 'Adesso Paris', 3),(10, 'Adesso Marsilya', 3),(11, 'Adesso Nice', 3),(12, 'Adesso Lyon', 3)," +
                "(13, 'Adesso Amsterdam', 4),(14, 'Adesso Rotterdam', 4),(15, 'Adesso Lahey', 4),(16, 'Adesso Eindhoven', 4)," +
                "(17, 'Adesso Lisbon', 5),(18, 'Adesso Porto', 5),(19, 'Adesso Braga', 5),(20, 'Adesso Coimbra', 5)," +
                "(21, 'Adesso Roma', 6),(22, 'Adesso Milano', 6),(23, 'Adesso Venedik', 6),(24, 'Adesso Napoli', 6)," +
                "(25, 'Adesso Sevilla', 7),(26, 'Adesso Madrid', 7),(27, 'Adesso Barselona', 7),(28, 'Adesso Granada', 7)," +
                "(29, 'Adesso Brüksel', 8),(30, 'Adesso Brugge', 8),(31, 'Adesso Gent', 8),(32, 'Adesso Anvers', 8);" +
                "SET IDENTITY_INSERT FootballTeams OFF");
        }
    }
}
