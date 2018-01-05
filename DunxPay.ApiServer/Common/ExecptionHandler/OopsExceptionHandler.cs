using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace DunxPay.ApiServer.Common.ExecptionHandler
{
    /// <summary>
    /// 全局异常处理器
    /// </summary>
    public class OopsExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    status = "error",
                    status_code = 500,
                    message = "对不起,在处理你的请求时出遇到了问题."
                });
            response.Headers.Add("X-Error", "");
            context.Result = new ResponseMessageResult(response);
        }

        #region Overrides of ExceptionHandler

        /// <summary>When overridden in a derived class, handles the exception asynchronously.</summary>
        /// <returns>A task representing the asynchronous exception handling operation.</returns>
        /// <param name="context">The exception handler context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var statusCode = 500;
            var message = "对不起,在处理你的请求时出遇到了问题.";
            if (context.Exception is UnauthorizedException)
            {
                message = "你的访问权限不足";
                statusCode = 403;
            }
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    status = "error",
                    status_code = statusCode,
                    message
                });
            response.Headers.Add("X-Error", "");
            context.Result = new ResponseMessageResult(response);
            return Task.FromResult(response);
        }

        #endregion

        private class TextPlainErrorResult : IHttpActionResult
        {
            private HttpRequestMessage Request { get; set; }

            private string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(Content),
                    RequestMessage = Request
                };
                return Task.FromResult(response);
            }
        }
    }
}