using System.Web.Http;

namespace apod.Controllers
{
    [RoutePrefix("/ApodController")]
    public class ApodController : ApiController
    {

        [Route("GetApod")]
        [HttpGet]
        public IHttpActionResult GetApod()
        {



            return Ok();
        }
    }
}
