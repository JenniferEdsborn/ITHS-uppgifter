using Microsoft.AspNetCore.Mvc;

namespace Films.API.Controllers
{ 
    [ApiController]             // vi arbetar lokalt mot en server som heter localhost, med portnummer 6001 -> localhost:6001/api/WeatherForecast (v�r lokala s�kv�g)
    [Route("api/[controller]")] // om vi hade arbetat mot en extern server hade vi haft dom�nnamn, ex (https://)mysite.com/api/WeatherForecast
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}