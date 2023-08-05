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

        public DbSet<FootballCup> FootballCups { get; private set; } = null!;
        public DbSet<FootballGroup> Groups { get; private set; } = null!;
        public DbSet<FootballCupGroups> CupGroups { get; private set; } = null!;

        public WorldCupDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();//for dev
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballGroup>()
                .HasData(Enum
                    .GetValues<FootballGroups>()
                    .Select(g => new FootballGroup(g))
                );

            modelBuilder.Entity<Country>()
                .HasData(new[] {
                    new Country(1, "Germany", "GER"),
                    new Country(2, "Turkey", "TUR"),
                    new Country(3, "France", "FRA"),
                    new Country(4, "Netherlands", "NED"),
                    new Country(5, "Portugal", "POR"),
                    new Country(6, "Italy", "ITA"),
                    new Country(7, "Spain", "SPA"),
                    new Country(8, "Belgium", "BEL"),
                });

            modelBuilder.Entity<FootballTeam>()
                .HasData(new[]
                {
                    new FootballTeam(1, "Adesso Berlin", 1),
                    new FootballTeam(2, "Adesso Frankfurt", 1),
                    new FootballTeam(3, "Adesso Mu¨nih", 1),
                    new FootballTeam(4, "Adesso Dortmund", 1),
                    new FootballTeam(5, "Adesso Berlin", 2),
                    new FootballTeam(6, "Adesso I?stanbul", 2),
                    new FootballTeam(7, "Adesso I?zmir", 2),
                    new FootballTeam(8, "Adesso Antalya", 2),
                    new FootballTeam(9, "Adesso Paris", 3),
                    new FootballTeam(10, "Adesso Marsilya", 3),
                    new FootballTeam(11, "Adesso Nice", 3),
                    new FootballTeam(12, "Adesso Lyon", 3),
                    new FootballTeam(13, "Adesso Amsterdam", 4),
                    new FootballTeam(14, "Adesso Rotterdam", 4),
                    new FootballTeam(15, "Adesso Lahey", 4),
                    new FootballTeam(16, "Adesso Eindhoven", 4),
                    new FootballTeam(17, "Adesso Lisbon", 5),
                    new FootballTeam(18, "Adesso Porto", 5),
                    new FootballTeam(19, "Adesso Braga", 5),
                    new FootballTeam(20, "Adesso Coimbra", 5),
                    new FootballTeam(21, "Adesso Roma", 6),
                    new FootballTeam(22, "Adesso Milano", 6),
                    new FootballTeam(23, "Adesso Venedik", 6),
                    new FootballTeam(24, "Adesso Napoli", 6),
                    new FootballTeam(25, "Adesso Sevilla", 7),
                    new FootballTeam(26, "Adesso Madrid", 7),
                    new FootballTeam(27, "Adesso Barselona", 7),
                    new FootballTeam(28, "Adesso Granada", 7),
                    new FootballTeam(29, "Adesso Bru¨ksel", 8),
                    new FootballTeam(30, "Adesso Brugge", 8),
                    new FootballTeam(31, "Adesso Gent", 8),
                    new FootballTeam(32, "Adesso Anvers", 8),

                });
        }
    }
}
