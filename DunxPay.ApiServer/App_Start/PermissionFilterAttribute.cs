using System;
using System.Web;
using System.Web.Mvc;
using UserContext = DunxPay.ApiServer.Util.UserManager.UserContext;

namespace DunxPay.ApiServer
{
    /// <summary>
    /// 权限过滤器
    /// </summary>
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        public bool CheckPermission
        {
            get { return _checkPermission; }
            set { _checkPermission = value; }
        }

        /// <summary>
        /// 操作码
        /// </summary>
        public string ActionCode { get; set; }
        /// <summary>
        /// 访问请求路由
        /// </summary>
        public string RequestRoute { get; set; }

        /// <summary>
        /// 是否验证权限
        /// </summary>
        private bool _checkPermission=true;
        private string _area;

        public PermissionFilterAttribute()
        {
            ActionCode = "";
            RequestRoute = "";
        }
        /// <summary>
        /// Action加上[PermissionFilter]在执行action之前执行以下代码，通过[PermissionFilter(ActionCode="Index")]指定参数
        /// </summary>
        /// <param name="filterContext">页面传过来的上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //取出区域的控制器Action,id
            var ctlName = filterContext.Controller.ToString();
            //var routeData = filterContext.RequestContext.RouteData;
            var routeInfo = ctlName.Split('.');
            var action = filterContext.ActionDescriptor.ActionName.ToLower();
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();

            var iAreas = Array.IndexOf(routeInfo, "Areas");
            if (iAreas > 0)
            {
                //取区域及控制器
                _area = routeInfo[iAreas + 1];
            }
            //var ctlIndex = Array.IndexOf(routeInfo, "Controllers");
            //ctlIndex++;
            //var controller = routeInfo[ctlIndex].Replace("Controller", "").ToLower();
    

            #region url handler
            //var url = HttpContext.Current.Request.Url.ToString().ToLower();
            //var urlArray = url.Split('/');
            //var urlCtlIndex = Array.IndexOf(urlArray, controller);
            //urlCtlIndex++;
            //if (urlArray.Count() > urlCtlIndex)
            //{
            //    action = urlArray[urlCtlIndex];
            //}
            //urlCtlIndex++;
            //if (urlArray.Count() > urlCtlIndex)
            //{
            //    id = urlArray[urlCtlIndex];
            //}
            ////url
            //action = string.IsNullOrEmpty(action) ? "Index" : action;
            //var actionIndex = action.IndexOf("?", 0);
            //if (actionIndex > 1)
            //{
            //    action = action.Substring(0, actionIndex);
            //}
            //id = string.IsNullOrEmpty(id) ? "" : id; 
            #endregion


            //URL路径
            //var filePath = HttpContext.Current.Request.FilePath;
            if (ValiddatePermission(controller, action))
            {
            }
            else
            {
                filterContext.Result = new EmptyResult();
            }
        }
        public bool ValiddatePermission(string controller, string action)
        {
            if (!_checkPermission)
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
            //如果存在区域,Seesion保存（区域+控制器）

            if (RequestRoute.Trim().Length > 0)
            {
                controller = RequestRoute;
            }
            else
            {
                if (!string.IsNullOrEmpty(_area))
                {
                    controller = _area + "/" + controller;
                }
            }
            controller = controller.ToLower().Trim('/').Trim();
            var url = string.Format("{0}/{1}", controller, action);
            //查询当前Action 是否有操作权限
            var hasPermission = UserContext.Permissions.Exists(x => string.Equals(x.ActionCode.Trim(), actionName.Trim(), StringComparison.CurrentCultureIgnoreCase) && url == x.RequestUrl);
            //.Where(a => a.KeyCode.ToLower() == actionName.ToLower()).Count();
            if (hasPermission)
            {
                bResult = true;
            }
            else
            {
                HttpContext.Current.Response.Write("你没有操作权限，请联系管理员！");
            }
            #endregion

            return bResult;
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }


}