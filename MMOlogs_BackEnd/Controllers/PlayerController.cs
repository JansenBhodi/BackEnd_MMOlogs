
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

        private readonly ILogger<PlayerController> _logger;
        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AllListedPlayers()
        {
            List<MmoPlayer> result = new List<MmoPlayer>();
            foreach(PlayerDB playerDB in _playerRepo.GetListedPlayers())
            {
                result.Add(new MmoPlayer(playerDB));

            }
            return Ok(new
            {
                data = result,
                totalCount = result.Count(),
                success = true
            });
        }
        
        [HttpGet("{id}")]
        public MmoPlayer PlayerById(int id)
        {
            try
            {
                return new MmoPlayer(_playerRepo.GetPlayerById(id));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
