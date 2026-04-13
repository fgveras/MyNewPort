using Microsoft.AspNetCore.Mvc;

namespace apod.Controllers
{
    [ApiController]
    [Route("[controller]")]  
    public class ApodController : ControllerBase
    {
        [HttpGet("teste")]  
        public IActionResult Teste()
        {
            return Ok(new { message = "200" });
        }

        [HttpGet("GetApod")] 
        public IActionResult GetApod()
        {
            return Ok();
        }
    }
}