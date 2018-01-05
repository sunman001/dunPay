using DunxPay.ApiServer.Common.ExecptionHandler;
using DunxPay.ApiServer.Util.UserManager;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DunxPay.ApiServer
{
    /// <summary>
    /// 权限过滤器
    /// </summary>
    public class ApiPermissionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 是否验证权限
        /// </summary>
        public bool CheckPermission { get; set; }

        /// <summary>
        /// 操作码
        /// </summary>
        public string ActionCode { get; set; }
        /// <summary>
        /// 访问请求路由
        /// </summary>
        public string RequestRoute { get; set; }

        
        //private bool _checkPermission = true;
        private string _area;

        public ApiPermissionFilterAttribute()
        {
            ActionCode = "";
            RequestRoute = "";
        }

        #region Overrides of ActionFilterAttribute

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            //取出区域的控制器Action,id
            var ctlName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            var routeData = actionContext.RequestContext.RouteData;
            var platform = routeData.Values["namespace"].ToString();

            var routeInfo = ctlName.Split('.');
            var action = actionContext.ActionDescriptor.ActionName.ToLower();
            var controller = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower().Replace("controller", "");

            var iAreas = Array.IndexOf(routeInfo, "Areas");
            if (iAreas > 0)
            {
                //取区域及控制器
                _area = routeInfo[iAreas + 1].ToLower();
            }
            //var ctlIndex = Array.IndexOf(routeInfo, "Controllers");
            //ctlIndex++;
            //var controller = routeInfo[ctlIndex].Replace("Controller", "").ToLower();


            //URL路径
            //var filePath = HttpContext.Current.Request.FilePath;
            if (!ValiddatePermission(platform, controller, action))
            {
                //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, actionContext.ModelState);
                throw new UnauthorizedException();
            }
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        #endregion
        /// <summary>
        /// 验证当前用户访问的路径是否有权限
        /// </summary>
        /// <param name="platform">平台[admin]</param>
        /// <param name="controller">当前控制器名称</param>
        /// <param name="action">当前操作名称</param>
        /// <returns></returns>
        public bool ValiddatePermission(string platform, string controller, string action)
        {
            if (!CheckPermission)
            {
                return true;
            }
            if (UserContext.IsSuperAdmin)
            {
                return true;
            }
            var bResult = false;
            var actionName = string.IsNullOrEmpty(ActionCode) ? action : ActionCode;

            #region MyRegion
            //检测当前controller是否已赋权限值，如果没有从

            if (RequestRoute.Trim().Length > 0)
            {
                controller = RequestRoute;
            }
            else
            {
                if (!string.IsNullOrEmpty(_area))
                {
                    controller = _area.ToLower() + "/" + controller;
                }
            }
            controller = controller.ToLower().Trim('/').Trim();
            var url = string.Format("{0}/{1}/{2}", platform, controller, action).Trim('/').Trim();
            //查询当前Action 是否有操作权限
            var hasPermission = UserContext.Permissions.Exists(x => string.Equals(x.ActionCode.Trim(), actionName.Trim(), StringComparison.CurrentCultureIgnoreCase) && url == x.RequestUrl.Trim('/').Trim());
            if (hasPermission)
            {
                bResult = true;
            }
            else
            {
                //HttpContext.Current.Response.Write("你没有操作权限，请联系管理员！");
            }
            #endregion

            return bResult;
        }

    }


}