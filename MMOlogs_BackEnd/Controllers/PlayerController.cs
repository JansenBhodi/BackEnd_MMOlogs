using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Classes;
using Repository;
using Repository.Classes;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Logic;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;

namespace MMOlogs_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayersLogic _playerLogic = new PlayersLogic(new MmoPlayerCalls());

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

        
        [HttpGet("{name}")]
        public IActionResult PlayerByName(string name)
        {
            try
            {
                return Ok(new 
                {
                    data = _playerLogic.GetPlayer(name),
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
        [HttpPost]
        public ActionResult<MmoPlayer> AddPlayer([FromBody]MmoPlayerCreateDTO player)
        {
            try
            {
                MmoPlayer result = _playerLogic.AddPlayer(player);
                return CreatedAtAction(
                        nameof(PlayerByName), new { Name = result.Name }, result
                        );
            }
            catch(ArgumentException ex)
            {
                return Ok(new
                {
                    message = ex.Message,
                    success = false
                });
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    success = false,
                    code = 404
                });
            }
        }
    }
}
