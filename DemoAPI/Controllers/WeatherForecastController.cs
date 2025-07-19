using DemoAPI.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly JwtHelper _jwt;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, JwtHelper jwt)
        {
            _logger = logger;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult Login(string userName, string password)
        {
            if (userName == "admin" && password == "1234")
            {
                var token = _jwt.GenerateToken(userName, "Admin");
                return Ok(new { token });
            }

            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
