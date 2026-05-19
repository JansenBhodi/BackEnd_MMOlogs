using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Classes;

using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Logic;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;

namespace MMOlogs_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : BaseController
    {
        private readonly PlayersLogic _playerLogic = new PlayersLogic(new MmoPlayerCalls());
        public PlayerController()
        {

        }

        [HttpGet]
        public IActionResult AllListedPlayers()
        {
            try
            {
                List<MmoPlayer> result = _playerLogic.GetListedPlayers();

                return HandleSuccess(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("{name}")]
        public IActionResult PlayerByName(string name)
        {
            try
            {
                MmoPlayer result = _playerLogic.GetPlayer(name);
                if (result == null)
                {
                    throw new InvalidOperationException(message: "No User was found with this name");
                }
                return HandleSuccess(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
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
                    message = ex.Message,
                    code = 404
                });
            }
        }
    }
}
