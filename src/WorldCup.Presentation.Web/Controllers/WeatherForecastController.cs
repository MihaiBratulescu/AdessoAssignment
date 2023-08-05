using Microsoft.AspNetCore.Mvc;

namespace WorldCup.Presentation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<object> Get()
        {
            return Enumerable.Range(1, 5)
                .Select(index => new object())
                .ToArray();
        }
    }
}