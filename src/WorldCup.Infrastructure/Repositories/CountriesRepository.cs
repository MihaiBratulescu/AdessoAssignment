using Microsoft.EntityFrameworkCore;
using WorldCup.Application.Interfaces.Repositories.Geo;
using WorldCup.Domain.AggregateModels.Geo;
using WorldCup.Infrastructure.Database.Context;

namespace WorldCup.Infrastructure.Repositories
{
    internal class CountriesRepository : Repository<WorldCupDbContext, Country, int>, ICountriesRepository
    {
        public CountriesRepository(WorldCupDbContext ctx) : base(ctx) { }

        public Task<Country[]> GetAllAsync()
        {
            return context.Countries
                .AsNoTracking()
                .ToArrayAsync();
        }

        public Task<Country?> GetByCodeAsync(string code)
        {
            return context.Countries
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ISOCode == code);
        }
    }
}
