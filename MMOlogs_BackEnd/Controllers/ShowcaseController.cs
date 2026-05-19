using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MMOlogs_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowcaseController : BaseController
    {
        // GET: api/<PlayerTestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PlayerTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlayerTestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //Not yet implemented on either side, low priority
            throw new NotSupportedException();
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
