using Microsoft.Web.Http;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v2
{
    [ApiVersion("2.0")]
    [RoutePrefix("api/admin")]
    public class DemoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Default()
        {
            return Ok("default for version 2.0 from admin client.");
        }
    }
}
