using DunxPay.ApiServer.Util.UserManager;
using Microsoft.Web.Http;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiAuthorize]
    [ApiVersion("1.0")]
    public class LocUserController : ApiController
    {
        [HttpGet]
        [ApiPermissionFilter(ActionCode = "view")]
        public IHttpActionResult FindById(int? id)
        {
            var user = UserContext.User;
            var clientId = user.ClientId;
            return Ok(user);
        }
    }
}