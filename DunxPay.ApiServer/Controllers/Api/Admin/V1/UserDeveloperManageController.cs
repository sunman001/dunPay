using DunxPay.Core.SqlTranslate;
using DunxPay.Domain.QueryModel.Admin.UserManage;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin.UserManage;
using System.Linq;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    public class UserDeveloperManageController : ApiController
    {
        private readonly IJmpUserService _iJmpUserService;

        public UserDeveloperManageController(IJmpUserService iJmpUserService)
        {
            _iJmpUserService = iJmpUserService;
        }

        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "VIEW")]
        public IHttpActionResult List(DeveloperCommand model)
        {
            string stat = string.IsNullOrEmpty(model.SearchState) ? "1" : model.SearchState;//用户状态


            var orderby = "order by" + " " + model.Sort + " " + model.Order;

            var list = _iJmpUserService.FindPagedListBysql(model.SearchType, model.SearchKey, stat, model.Category, model.Relation_type, model.Auditstate, model.RiskM, orderby, model.Page, model.Rows);

            var gridModel = new ViewModel.DataSource.DataSourceResult<DeveloperModel>(list)
            {
                Rows = list.Select(x =>
                {
                    var m = x.ToModel();
                    return m;
                })
            };


            return Ok(gridModel);
        }

        /// <summary>
        /// 一键启用禁用
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult EnabledOrDisable(DeveloperCommand mod)
        {
            var ReturnStart = _iJmpUserService.UpdateStart(int.Parse(mod.SearchState), mod.IdList);

            return Ok(ReturnStart);
        }

    }
}
