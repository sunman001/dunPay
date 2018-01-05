
using DunxPay.Core.SqlTranslate;
using DunxPay.Domain.DunBase;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin;
using System.Linq;
using System.Web.Http;


namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiAuthorize, ApiPermissionFilter]
    public class LoggerController : ApiController
    {

        private readonly IDxLoggerService _dxLoggerService;
        public LoggerController(IDxLoggerService dxLoggerService)
        {
            _dxLoggerService = dxLoggerService;
        }
        [HttpPost, ApiPermissionFilter(ActionCode = "VIEW")]
        public IHttpActionResult List(LogSearchCommand command)
        {
            var prelicateBuilder = PredicateBuilder.Create<DxAdminOperationLog>(null);
            if (!string.IsNullOrEmpty(command.Txtseach))
            {
                switch (command.Field)
                {
                    case "1":
                        prelicateBuilder = prelicateBuilder.And(x => x.UserId.ToString() == command.Txtseach);
                        break;
                    case "2":
                        prelicateBuilder = prelicateBuilder.And(x => x.IpAddress == command.Txtseach);
                        break;
                    case "3":
                        prelicateBuilder = prelicateBuilder.And(x => x.UserId.ToString() == command.Txtseach);
                        break;
                }
            }
            if (command.Logtype > 0)
            {
                prelicateBuilder = prelicateBuilder.And(x => x.LogType == command.Logtype);
            }
            var orderby = command.Sort + " " + command.Order;
            var list = _dxLoggerService.FindPagedList(prelicateBuilder, orderby, command.Page, command.Rows);
            var gridModel = new ViewModel.DataSource.DataSourceResult<DxAdminOperationLog>(list)
            {
                Rows = list.Select(x =>
                {
                    var m = x.ToModel();
                    return m;
                })
            };
            return Ok(gridModel);
        }
    }
}