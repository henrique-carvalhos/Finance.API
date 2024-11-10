using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserControllers : ControllerBase
    {
        public UserControllers()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(int id)
        {
            return NoContent();
        }
    }
}
