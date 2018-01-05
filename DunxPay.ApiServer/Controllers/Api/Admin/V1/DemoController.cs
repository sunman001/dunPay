using Microsoft.Web.Http;
using System;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/admin")]
    public class DemoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Default()
        {
            throw new NullReferenceException("null 123");
            return Ok("default for version 1.0 from admin client.");
        }
    }
}