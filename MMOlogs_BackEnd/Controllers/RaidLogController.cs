using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;
using BusinessLogic.DTO.RaidLogDTO_s;
using BusinessLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MMOlogs_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RaidLogController : BaseController
    {
        private readonly RaidLogLogic _logic = new RaidLogLogic(new RaidLogCalls());
        
        public RaidLogController() 
        {
        
        }
        

        [HttpPost]
        public IActionResult AddRaidLog([FromBody] RaidLogCreateDTO input)
        {
            try
            {
                List<RaidLog> outcome = _logic.AddRaidLog(input);
                return HandleSuccess(outcome);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
