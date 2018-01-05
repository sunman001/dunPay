using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Developer.v2
{
    //[RoutePrefix("api/developer/{apiVersion:apiVersionConstraint(v2)}")]
    public class DemoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Default()
        {
            return Ok("default for version 2.0 from developer client.");
        }
    }
}
