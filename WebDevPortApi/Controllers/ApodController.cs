using Microsoft.AspNetCore.Mvc;
using WebDevPortRn.APOD;
using WebDevPortRn.Models;
using WebDevDAL;
using static WebDevDAL.RequestModels;

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
        public IActionResult Teste()
        {

            GenericResponse<GetPhotoModel> ret = new GenericResponse<GetPhotoModel>();

            ret.Data = _apodService.GetPhoto();

            return Ok(ret);
        }

        [HttpGet("GetPriod")]
        public IActionResult Teste([FromQuery] DateTime intialDate, [FromQuery] DateTime finalDate)
        {

            GenericResponse<List<GetPhotoModel>> ret = new GenericResponse<List<GetPhotoModel>>();

            ret.Data = _apodService.GetPhotoByPeriod(intialDate, finalDate);

            return Ok(ret);
        }

        [HttpGet("GetApod")] 
        public IActionResult GetApod()
        {
            return Ok();
        }

        [HttpPut("CreatePhoto")]
        public IActionResult CreatePhoto([FromBody] GetPhotoModel record)
        {

            GenericResponse<string> ret = new GenericResponse<string>();

            ret.Data = _apodService.CreatePhoto(record);

            return Ok();
        }
    }
}