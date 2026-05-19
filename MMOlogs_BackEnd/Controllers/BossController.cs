using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;
using BusinessLogic.Logic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MMOlogs_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BossController : ControllerBase
    {
        private readonly BossLogic _bossLogic = new BossLogic(new BossCalls());
        public BossController()
        {

        }

        [HttpGet]
        public IActionResult GetBosses()
        {
            try
            {
                List<BossOverviewDTO> Bosses = _bossLogic.GetBosses();

                return Ok(new
                {
                    data = Bosses,
                    success = true,
                    code = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBoss(int id)
        {
            try
            {
                BossDetailDTO result = _bossLogic.GetBoss(id);

                return Ok(new
                {
                    data = result,
                    success = true,
                    code = 200
                });
            }
            catch (ArgumentException ex)
            {
                return Ok(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return Ok(new
                {
                    message = ex.Message,
                    success = false
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
        public ActionResult<Boss> CreateBoss([FromBody] BossCreateDTO boss)
        {
            try
            {
                Boss result = _bossLogic.AddBoss(boss);

                return CreatedAtAction(
                        nameof(GetBoss), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
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
