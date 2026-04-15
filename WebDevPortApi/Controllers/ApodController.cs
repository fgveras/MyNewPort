using Microsoft.AspNetCore.Mvc;
using WebDevPortRn.APOD;
using WebDevPortRn.Models;

namespace apod.Controllers
{

    public class GlobalResponse
    {
        public object? Data { get; set; }
        public bool Error { get; set; } = false;
    }

    [ApiController]
    [Route("[controller]")]  
    public class ApodController : ControllerBase
    {

        private readonly ApodRn _apodService;

        public ApodController(ApodRn apodService)
        {
            _apodService = apodService;
        }

        [HttpGet("teste")]  
        public async Task<IActionResult> Teste()
        {

            GetPhotoModel response = await _apodService.GetPhoto();

            return Ok(response);
        }

        [HttpGet("GetPriod")]
        public async Task<IActionResult> Teste([FromQuery] DateTime intialDate, [FromQuery] DateTime finalDate)
        {

            List<GetPhotoModel> response = await _apodService.GetPhotoByPeriod(intialDate, finalDate);

            return Ok(response);
        }

        [HttpGet("GetApod")] 
        public IActionResult GetApod()
        {
            return Ok();
        }
    }
}