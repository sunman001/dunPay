using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DunxPay.Core.SqlTranslate;
using DunxPay.Domain.DunBase;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin.User;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiAuthorize, ApiPermissionFilter]
    public class UserController : ApiController
    {
        private readonly IJmpUserService _iJmpUserService;

        public UserController(IJmpUserService iJmpUserService)
        {
            _iJmpUserService = iJmpUserService;
        }
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult comboList(ComboListSearchCommand command)
        {
            var prelicateBuilder = PredicateBuilder.Create<JmpUser>(null);

            if (!string.IsNullOrEmpty(command.Keyword))
            {
                switch (command.SearchType)
                {
                    case "1":
                        prelicateBuilder = prelicateBuilder.And(x => x.URealname.ToString() == command.Keyword);
                        break;
                    case "2":
                        prelicateBuilder = prelicateBuilder.And(x => x.UEmail == command.Keyword);
                        break;
                    case "3":
                        prelicateBuilder = prelicateBuilder.And(x => x.UIdnumber.ToString() == command.Keyword);
                        break;
                    case "4":
                        prelicateBuilder = prelicateBuilder.And(x => x.UBlicensenumber.ToString() == command.Keyword);
                        break;
                }
            }
            //var orderby = command.Sort + " " + command.Order;
            var list = _iJmpUserService.FindPagedList(prelicateBuilder, command.Sort, command.Order, command.Page, command.Rows);
            var gridModel = new ViewModel.DataSource.DataSourceResult<JmpUser>(list)
            {
                Rows = list.Select(x =>
                {
                    var m = x;
                    return m;
                })
            };
            return Ok(gridModel);
        }
    }
}
