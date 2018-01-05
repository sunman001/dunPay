using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace DunxPay.ApiServer.Common.Routing
{
    /// <summary>
    /// API版本约束
    /// </summary>
    public class ApiVersionConstraint : IHttpRouteConstraint
    {
        public ApiVersionConstraint(string allowedVersion)
        {
            AllowedVersion = allowedVersion.ToLowerInvariant();
        }
        /// <summary>
        /// 允许的API版本号
        /// </summary>
        public string AllowedVersion { get; private set; }
        /// <summary>
        /// 匹配版本
        /// </summary>
        /// <param name="request">当前的请求</param>
        /// <param name="route">路由对象</param>
        /// <param name="parameterName">参数名称</param>
        /// <param name="values">数据字典</param>
        /// <param name="routeDirection">路由方向</param>
        /// <returns></returns>
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return AllowedVersion.Equals(value.ToString().ToLowerInvariant());
            }
            return false;
        }
    }
}