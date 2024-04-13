using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiscinaController : ControllerBase
    {
        // GET: api/<PiscinaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PiscinaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PiscinaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PiscinaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PiscinaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
