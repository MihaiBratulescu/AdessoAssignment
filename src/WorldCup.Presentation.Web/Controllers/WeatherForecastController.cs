using Microsoft.AspNetCore.Mvc;
using WorldCup.Application.Interfaces.Repositories.Geo;

namespace WorldCup.Presentation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICountriesRepository repo;

        public WeatherForecastController(ICountriesRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<object> Get()
        {
            await repo.GetAllAsync();

            return Enumerable.Range(1, 5)
                .Select(index => new object())
                .ToArray();
        }
    }
}