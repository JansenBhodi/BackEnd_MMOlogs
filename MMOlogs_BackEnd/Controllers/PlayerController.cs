
using BusinessLogic;
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
        private PlayersLogic _playerLogic = new PlayersLogic();

        private readonly ILogger<PlayerController> _logger;
        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AllListedPlayers()
        {
            List<MmoPlayer> result = new List<MmoPlayer>();
            try
            {
                result = _playerLogic.GetListedPlayers();

                return Ok(new
                {
                    data = result,
                    totalCount = result.Count(),
                    success = true,
                    code = 200
                });
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    success = false,
                    code = 404
                });
            }
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
