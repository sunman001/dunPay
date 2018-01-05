using System.Web.Http;

namespace DunxPay.ApiServer.Common.Routing
{
    /// <summary>
    /// API版本路由属性类
    /// </summary>
    public class ApiVersionRoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v1)}";
        private const string PrefixRouteBase = RouteBase + "/";
        public ApiVersionRoutePrefixAttribute(string routePrefix)
            : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        {
        }
    }
}