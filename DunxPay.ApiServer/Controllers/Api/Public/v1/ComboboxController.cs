using DunxPay.ViewModel.EasyuiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DunxPay.ApiServer.Extensions;
using DunxPay.Core.Extensions;
using DunxPay.Global.Enums;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.ApiServer.Controllers.Api.Public.v1
{
    public class ComboboxController : ApiController
    {
        private readonly IRbacService _rbacService;
        private readonly IDxBasicsModuleActionService _idxBasicsModuleActionService;
        private readonly IAppTypeService _iAppTypeService;
        private readonly IPaymodeService _iPaymodeService;
        private readonly IJmpRisklevelallocationService _iJmpRisklevelallocationService;
        private readonly IDxRoleService _idxRoleService;

        public ComboboxController(IRbacService rbacService, IDxBasicsModuleActionService idxBasicsModuleActionService, IAppTypeService iAppTypeService, IPaymodeService iPaymodeService, IDxRoleService idxRoleService, IJmpRisklevelallocationService iJmpRisklevelallocationService)

        {
            _rbacService = rbacService;
            _idxBasicsModuleActionService = idxBasicsModuleActionService;
            _iAppTypeService = iAppTypeService;
            _iPaymodeService = iPaymodeService;
            _iJmpRisklevelallocationService = iJmpRisklevelallocationService;

            _idxRoleService = idxRoleService;

        }
        /// <summary>
        /// 获取平台集合
        /// </summary>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetClient()
        {
            List<ComboboxModel> selectModes = new List<ComboboxModel>();

            foreach (var type in Enum.GetValues(typeof(DxClient)))
            {
                ComboboxModel selectModel = new ComboboxModel
                {
                    Id = (int)Enum.Parse(typeof(DxClient), type.ToString()),
                    Text = type.To<DxClient>().GetDescription(),
                    Selected = ((int)Enum.Parse(typeof(DxClient), type.ToString()) == 1) ? true : false
                };
                selectModes.Add(selectModel);
            }
            return Ok(selectModes);
        }

        /// <summary>
        /// 基础操作码集合
        /// </summary>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetBasicModuleAction()
        {
            List<ComboboxModel> selectModels = new List<ComboboxModel>();
            var ModuleActionList = _idxBasicsModuleActionService.FindAll();
            foreach (var action in ModuleActionList)
            {
                ComboboxModel selectModel = new ComboboxModel
                {
                    Id = action.Id,
                    Text = action.Name
                };
                selectModels.Add(selectModel);
            }
            return Ok(selectModels);
        }
        /// <summary>
        /// 获取下拉框树形模块菜单
        /// </summary>
        /// <param name="dxClientId"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetModule(string dxClientId)
        {

            var menus = _rbacService.FindMenusByUserIdAndClientId(0, dxClientId, true).Select(x => x.ToJsonModel()).ToList();
            var json = menus.BuildTreeMenu();
            return Ok(json);
        }
        /// <summary>
        /// 获取应用父类型集合
        /// </summary>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetAppType()
        {
            List<ComboboxModel> selectModels = new List<ComboboxModel>();
            var apptypeList = _iAppTypeService.FindListByClause(x => x.t_topid == 0);
            ComboboxModel selectModel1 = new ComboboxModel
            {
                Id = -1,
                Text = "请选择",
                Selected = true
            };
            selectModels.Add(selectModel1);

            ComboboxModel selectModel2 = new ComboboxModel
            {
                Id = 0,
                Text = "父级"

            };
            selectModels.Add(selectModel2);
            foreach (var apptype in apptypeList)
            {
                ComboboxModel selectModel = new ComboboxModel
                {
                    Id = apptype.t_id,
                    Text = apptype.t_name
                };
                selectModels.Add(selectModel);
            }
            return Ok(selectModels);
        }

        /// <summary>
        /// 正在用的应用类型
        /// </summary>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetAppTypePay()
        {
            var apptypeList = _iAppTypeService.FindListByPay();
            List<ComboboxModel> selectModels = new List<ComboboxModel>();
            ComboboxModel selectModel1 = new ComboboxModel
            {
                Id = 0,
                Text = "请选择应用类型",
                Selected = true
            };
            selectModels.Add(selectModel1);
            foreach (var apptype in apptypeList)
            {
                ComboboxModel selectModel = new ComboboxModel
                {
                    Id = apptype.t_id,
                    Text = apptype.t_name
                };
                selectModels.Add(selectModel);
            }
            return Ok(selectModels);
        }

        /// <summary>
        /// 根据父级查询子级应用类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetAppTypeByParentId(int id)
        {

            var apptypeList = _iAppTypeService.FindListByClause(x => x.t_topid == id);
            List<ComboboxModel> selectModels = new List<ComboboxModel>();
            ComboboxModel selectModel1 = new ComboboxModel
            {
                Id = 0,
                Text = "请选择应用类型",
                Selected = true
            };
            selectModels.Add(selectModel1);
            foreach (var apptype in apptypeList)
            {
                ComboboxModel selectModel = new ComboboxModel()
                {
                    Id = apptype.t_id,
                    Text = apptype.t_name
                };
                selectModels.Add(selectModel);
            }
            return Ok(selectModels);
        }

        /// <summary>
        /// 获取状态启用的支付类型
        /// </summary>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetPaymode()
        {
            var paymodeList = _iPaymodeService.FindListByClause(x => x.p_state == 1);
            List<ComboboxModel> selectModels = new List<ComboboxModel>();
            ComboboxModel selectModel1 = new ComboboxModel
            {
                Id = 0,
                Text = "支付类型",
                Selected = true
            };
            selectModels.Add(selectModel1);
            foreach (var paymode in paymodeList)
            {
                ComboboxModel selectModel = new ComboboxModel
                {
                    Id = paymode.p_id,
                    Text = paymode.p_name
                };
                selectModels.Add(selectModel);
            }
            return Ok(selectModels);
        }

        /// <summary>
        /// 风险等级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Getrisklevelallocation(int id)
        {
            var risklist = _iJmpRisklevelallocationService.FindRiskLevelByApptypeId(id);
            List<ComboboxModel> selectModels = new List<ComboboxModel>();
            ComboboxModel selectModel1 = new ComboboxModel
            {
                Id = 0,
                Text = "请选择风险等级",
                Selected = true
            };
            selectModels.Add(selectModel1);
            foreach (var paymode in risklist)
            {
                ComboboxModel selectModel = new ComboboxModel
                {
                    Id = paymode.RId,
                    Text = paymode.RName
                };
                selectModels.Add(selectModel);
            }
            return Ok(selectModels);
        }

        /// <summary>
        /// 根据平台ID查询平台角色
        /// </summary>
        /// <param name="dxClientId">平台ID</param>
        /// <returns></returns>
        [HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetRole(int id)
        {
            List<ComboboxModel> selectModels = new List<ComboboxModel>();
            var RoleList = _idxRoleService.FindListByClause(x => x.ClientId == id).Where(x => x.IsEnabled == true);
            ComboboxModel selectModel1 = new ComboboxModel
            {
                Id = 0,
                Text = "请选择",
                Selected = true
            };
            selectModels.Add(selectModel1);

            foreach (var role in RoleList)
            {
                ComboboxModel selectModel = new ComboboxModel
                {
                    Id = role.Id,
                    Text = role.Name
                };
                selectModels.Add(selectModel);
            }

            return Ok(selectModels);

        }

    }
}
