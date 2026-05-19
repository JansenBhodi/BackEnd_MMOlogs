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
    public class BossController : BaseController
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

                return HandleSuccess(Bosses);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBoss(int id)
        {
            try
            {
                BossDetailDTO result = _bossLogic.GetBoss(id);

                return HandleSuccess(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
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
