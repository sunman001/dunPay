using DunxPay.ApiServer.Extensions;
using DunxPay.ApiServer.Util.UserManager;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Public.v1
{
    [ApiAuthorize, ApiPermissionFilter]
    public class AccountController : ApiController
    {
        private readonly IRbacService _rbacService;
        public AccountController(IRbacService rbacService)
        {
            _rbacService = rbacService;
        }
        [HttpGet]
        public IHttpActionResult TokenStatus()
        {
            var message = "";
            var isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                message = "登录已失效,请重新登录";
            }
            return Ok(new { isAuthenticated, error = message });
        }

        [HttpGet]
        [ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Menu()
        {
            var message = "";
            var isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                message = "登录已失效,请重新登录";
                return Ok(new { isAuthenticated = false, error = message });
            }

            var menus = _rbacService.FindMenusByUserIdAndClientId(UserContext.Id, UserContext.ClaimsClient, UserContext.IsSuperAdmin).Select(x => x.ToJsonModel()).ToList();


            var json = menus.BuildTreeMenu();
            return Ok(new { isAuthenticated = true, error = message, menu = json });
        }

        [HttpGet, ApiPermissionFilter]
        public IHttpActionResult Permissions()
        {
            var req = Request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == "req").Value;
            var message = "";
            var isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                message = "登录已失效,请重新登录";
                return Ok(new { isAuthenticated = false, error = message });
            }
            var permissions = UserContext.FindPermissionsByRequestUrl(req);
            var toolbaButtonpPermissions = permissions.Where(x => x.IsButton && x.ButtonType == 1).ToList();
            var gridButtonpPermissions = permissions.Where(x => x.IsButton && x.ButtonType == 2).ToList();
            return Ok(new { isAuthenticated = true, toolbaButtonpPermissions, gridButtonpPermissions, error = message });
        }
    }
}
