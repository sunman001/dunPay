using DunxPay.ApiServer.Common.ExecptionHandler;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DunxPay.ApiServer
{
    /// <summary>
    /// API权限验证属性类
    /// </summary>
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        #region Overrides of AuthorizationFilterAttribute

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
            var name = principal.Identity.Name;
            if (!principal.Identity.IsAuthenticated)
            {
                //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Not allowed to access...bla bla");
                //return Task.FromResult<object>(null);
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Oops" };
                throw new UnauthorizedException();
            }

            //User is Authorized, complete execution
            return Task.FromResult<object>(null);
        }

        #endregion

        #region Overrides of AuthorizeAttribute

        /// <summary>Processes requests that fail authorization.</summary>
        /// <param name="actionContext">The context.</param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Forbidden,
                Content = new StringContent("Unauthorized request.")
            };
            //base.HandleUnauthorizedRequest(actionContext);
        }

        #endregion
    }
}