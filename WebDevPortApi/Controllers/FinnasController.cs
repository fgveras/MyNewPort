using Microsoft.AspNetCore.Mvc;
using WebDevPortRn.APOD;
using WebDevPortRn.Models;
using WebDevDAL;
using static WebDevDAL.RequestModels;
using WebDevPortRn.FINNAS;
using System.Data;

namespace FINNAS.Controllers
{

    [ApiController]
    [Route("[controller]")]  
    public class FinnasController : ControllerBase
    {

        private readonly Finnas _finnasService;

        public FinnasController(Finnas finnasService)
        {
            _finnasService = finnasService;
        }

        [HttpGet("GetFinnas")]  
        public IActionResult Teste()
        {

            GenericResponse<List<Dictionary<string, object>>> ret = new GenericResponse<List<Dictionary<string, object>>>();
            
            ret.Data = _finnasService.GetFinnas();

            return Ok(ret);
        }


    }
}