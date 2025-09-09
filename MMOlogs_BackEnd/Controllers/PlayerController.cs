
using Microsoft.AspNetCore.Mvc;
using MMOlogs_BackEnd.Classes;

namespace MMOlogs_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        public PlayerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IEnumerable<PlayerClass> Get()
        {
            return new PlayerClass[] {

            };
    }
}
