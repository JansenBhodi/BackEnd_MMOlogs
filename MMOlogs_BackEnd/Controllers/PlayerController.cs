
using Microsoft.AspNetCore.Mvc;
using MMOlogs_BackEnd.Classes;
using Repository;
using Repository.Classes;

namespace MMOlogs_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private PlayerRepository _playerRepo = new PlayerRepository();

        private readonly ILogger<WeatherForecastController> _logger;
        public PlayerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetListedPlayers")]
        public IEnumerable<MmoPlayer> Get()
        {
            List<MmoPlayer> result = new List<MmoPlayer>();
            foreach(PlayerDB playerDB in _playerRepo.GetListedPlayers())
            {
                result.Add(new MmoPlayer(playerDB));

            }
            return result;
        }
    }
}
