using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Developer.v1
{
    //[ApiVersionRoutePrefix("api/developer")]
    public class DemoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Default()
        {
            return Ok("default for version 1.0 from developer client.");
        }
    }
}
