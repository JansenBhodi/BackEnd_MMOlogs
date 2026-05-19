using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;
using BusinessLogic.DTO.MechanicDTO_s;
using BusinessLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MMOlogs_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MechanicsController : BaseController
    {
        private readonly MechanicLogic _mechanicLogic = new MechanicLogic(new MechanicsCalls());
        public MechanicsController()
        {

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                MechanicDetailDTO result = _mechanicLogic.GetMechanic(id);
                if (result == null)
                {
                    throw new InvalidOperationException(message: "No mechanic was found with this id");
                }
                return HandleSuccess(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        public ActionResult<Mechanic> Post([FromBody]MechanicCreateDTO mechanic)
        {
            try
            {
                Mechanic result = _mechanicLogic.AddMechanic(mechanic);

                return CreatedAtAction(
                        nameof(Get), new { id = result.Id }, result
                        );
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

        // PUT api/<PlayerTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //Not yet implemented on either side, low priority
            throw new NotSupportedException();
        }

        // DELETE api/<PlayerTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Not yet implemented on either side, low priority
            throw new NotSupportedException();
        }
    }
}
