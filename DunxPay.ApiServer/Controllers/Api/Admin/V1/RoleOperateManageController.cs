using DunxPay.ApiServer.Extensions;
using DunxPay.ApiServer.Util.LogWriter;
using DunxPay.ApiServer.Util.UserManager;
using DunxPay.Core;
using DunxPay.Core.SqlTranslate;
using DunxPay.Domain.DunBase;
using DunxPay.Global.Enums;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin;
using DunxPay.ViewModel.DataSource;
using DunxPay.ViewModel.DunBase.Rbac;
using DunxPay.ViewModel.DunBase.RoleManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiAuthorize, ApiPermissionFilter]
    public class RoleOperateManageController : ApiController
    {
        private readonly IAdminLogFactory _logFactory;
        private readonly IDxModuleService _dxModuleService;
        private readonly IDxRoleService _dxRoleService;
        private readonly IDxPermissionActionService _dxPermissionActionService;
        private readonly IDxPermissionService _dxPermissionService;
        public RoleOperateManageController(IDxRoleService dxRoleService, IDxModuleService dxModuleService, IDxPermissionActionService dxPermissionActionService, IDxPermissionService dxPermissionService, IAdminLogFactory logFactory)
        {
            _dxRoleService = dxRoleService;
            _dxModuleService = dxModuleService;
            _dxPermissionActionService = dxPermissionActionService;
            _dxPermissionService = dxPermissionService;
            _logFactory = logFactory;
        }

        /// <summary>
        /// 运营管理展示页
        /// </summary>
        /// <param name="cbase">传入参数</param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false, ActionCode = "VIEW")]
        public IHttpActionResult List(RoleManageSearchCommand rolemodel)
        {
            var prelicateBuilder = PredicateBuilder.Create<DxRole>(null);

            prelicateBuilder = prelicateBuilder.And(x => x.ClientId == (int)DxClient.Administrator);

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

        /// <summary>
        /// 一键启用禁用
        /// </summary>
        /// <param name="rolemodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult EnabledOrDisable(RoleManageSearchCommand rolemodel)
        {
            var ReturnStart = _dxRoleService.UpdateStart(rolemodel.SearchState, rolemodel.IdList);

            return Ok(ReturnStart);
        }
        /// <summary>
        /// 权限模块 以及权限信息查询
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public IHttpActionResult Permissionset(int RoleId)
        {
            var dxClientId = (int)DxClient.Administrator;
            var role = _dxRoleService.FindById(RoleId);
            var menus = _dxModuleService.FindModuleListByClientId(dxClientId, role.IdentifyCode);
            var json = menus.BuildTreeMenu();
            return Ok(json);
        }

        /// <summary>
        /// 权限授权
        /// </summary>
        /// <param name="dxPermission"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Permissionsetopert(DxPermissionViewModel dxPermission)
        {
            var listPermission = _dxRoleService.FindPerssionByRoleId(dxPermission.RoleId);
            var role = _dxRoleService.FindById(dxPermission.RoleId);
            var listPermissionmodle = new List<DxPermission>();
            var listPermissionActionModel = new List<DxPermissionAction>();
            var idlist = new List<string>();
            //权限唯一标识集合
            if (listPermission.Count > 0)
            {
                var listp = listPermission.Select(x => new
                {
                    x.IdentifyCode
                }).Distinct().ToList();
                foreach (var identityCode in listp)
                {
                    idlist.Add(identityCode.IdentifyCode);
                }
            }
            //模块集合去重复
            var list = dxPermission.DxPerMissionAction.Select(x => new
            {
                x.ModuleIdentifyCode
            }).Distinct().ToList();

            //权限集合 和权限操作码集合
            foreach (var dxPerMissionAction in list)
            {
                PermissionIdentifyCodeBuilder moduleIdentifyCodeBuilder = new PermissionIdentifyCodeBuilder();
                var identifyCode = moduleIdentifyCodeBuilder.Build;
                var dxPermissionModel = new DxPermission
                {
                    IdentifyCode = identifyCode,
                    CreatedBy = UserContext.LoginName,
                    CreatedByUserId = UserContext.Id,
                    CreatedOn = DateTime.Now,
                    IsEnabled = true,
                    RoleIdentifyCode = role.IdentifyCode,
                    ModuleIdentifyCode = dxPerMissionAction.ModuleIdentifyCode,
                };

                var dxPermissionActionModel = dxPermission.DxPerMissionAction.FindAll(x => x.ModuleIdentifyCode == dxPermissionModel.ModuleIdentifyCode).Select(x =>
                    new DxPermissionAction
                    {
                        PermissionIdentifyCode = identifyCode,
                        Code = x.Code,
                        IsEnabled = true

                    }).ToList();
                listPermissionmodle.Add(dxPermissionModel);
                listPermissionActionModel.AddRange(dxPermissionActionModel);
            }
            var IsDeleted = listPermission.Count > 0 ? true : false;
            var a = _dxRoleService.PermissionSet(IsDeleted, idlist, listPermissionmodle, listPermissionActionModel);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "权限设置成功！";
                //添加操作日志
                _logFactory.Logger.OperateLog("设置权限", "设置的角色ID为'" + dxPermission.RoleId + "'");
            }
            else
            {

                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "权限设置失败！";

            }

            return Ok(dataSourceForm);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "Create")]
        public IHttpActionResult Create(DxRoleViewModel model)
        {
            RoleIdentifyCodeBuilder roleIdentifyCodeBuilder = new RoleIdentifyCodeBuilder();
            model.IdentifyCode = roleIdentifyCodeBuilder.Build;
            model.ClientId = (int)DxClient.Administrator;
            model.ClientName = DxClient.Administrator.GetDescription();
            model.CreatedBy = UserContext.LoginName;
            model.CreatedByUserId = UserContext.Id;
            model.IsEnabled = true;
            model.IsBuiltin = false;
            model.IsDeleted = false;
            var entity = model.ToEntity();
            entity.CreatedOn = DateTime.Now;
            int a = _dxRoleService.Insert(entity);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a > 0)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "添加成功！";
                //添加操作日志
                //logger.CreateLog("新增角色", entity);

            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "添加失败！";
            }

            return Ok(dataSourceForm);

        }

        [HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Edit(int id)
        {
            var model = _dxRoleService.FindById(id);
            var viewmodel = model.ToModel();
            return Ok(viewmodel);
        }

        [HttpPost, ApiPermissionFilter(ActionCode = "Edit")]
        public IHttpActionResult Edit(DxRole model)
        {
            var oldModel = _dxRoleService.FindById(model.Id);
            oldModel.Name = model.Name;
            oldModel.Description = model.Description;
            bool  a = _dxRoleService.Update(oldModel);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a )
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "修改成功！";
                //添加操作日志
                //logger.ModifyLog("修改角色",model,oldModel);

            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "修改失败！";
            }

            return Ok(dataSourceForm);

        }
    }
}
