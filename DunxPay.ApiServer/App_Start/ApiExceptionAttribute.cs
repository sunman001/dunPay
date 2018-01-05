using DunxPay.ApiServer.Common.ExecptionHandler;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace DunxPay.ApiServer
{
    /// <summary>
    /// api 接口异常过滤器
    /// </summary>
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //var response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            //{
            //    Content = new StringContent("An unhandled exception was thrown by server."),
            //    ReasonPhrase = "Internal Server Error. Please contact your administrator."
            //};
            //actionExecutedContext.Response = response;

            var exception = actionExecutedContext.Exception;
            if (exception is ApiException)
            {
                var ex = exception as ApiException;
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                    ex.StatusCode, ex.Message);
            }
            else if (exception is UnauthorizedException)
            {
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                        new HttpError("你的访问权限不足"));
            }
            else
            {
                //actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,new ApiException(HttpStatusCode.InternalServerError, "An unexpected error occured"));
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                        new HttpError(actionExecutedContext.Exception.Message));
                //new HttpError("服务器忙,请稍候再试..."));
            }
        }
    }
}