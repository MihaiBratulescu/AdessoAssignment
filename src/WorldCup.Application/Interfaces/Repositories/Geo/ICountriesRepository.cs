using WorldCup.Domain.AggregateModels.Geo;

namespace WorldCup.Application.Interfaces.Repositories.Geo
{
    public interface ICountriesRepository : IReadRepository<Country, int>
    {
        Task<Country[]> GetAllAsync();
        Task<Country?> GetByCodeAsync(string code);
    }
}
