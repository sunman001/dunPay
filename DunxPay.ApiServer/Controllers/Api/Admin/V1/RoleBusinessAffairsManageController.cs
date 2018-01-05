using DunxPay.Core.SqlTranslate;
using DunxPay.Domain.DunBase;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin;
using System.Linq;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    public class RoleBusinessAffairsManageController : ApiController
    {
        private readonly IDxRoleService _dxRoleService;
        public RoleBusinessAffairsManageController(IDxRoleService dxRoleService)
        {
            _dxRoleService = dxRoleService;
        }

        /// <summary>
        /// 商务管理展示页
        /// </summary>
        /// <param name="cbase">传入参数</param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "VIEW")]
        public IHttpActionResult List(RoleManageSearchCommand rolemodel)
        {
            var prelicateBuilder = PredicateBuilder.Create<DxRole>(null);

            prelicateBuilder = prelicateBuilder.And(x => x.ClientId == 3);

            var orderby = rolemodel.Sort + " " + rolemodel.Order;

            var list = _dxRoleService.FindPagedList(prelicateBuilder, orderby, rolemodel.Page, rolemodel.Rows);

            var gridModel = new ViewModel.DataSource.DataSourceResult<DxRole>(list)
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
