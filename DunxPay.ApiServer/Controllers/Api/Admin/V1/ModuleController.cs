using System;
using System.Collections;
using System.Linq;
using DunxPay.Services.Inter.DunBase;
using System.Threading;
using System.Web.Http;
using DunxPay.ApiServer.Extensions;
using DunxPay.ApiServer.Util.UserManager;
using DunxPay.Core;
using DunxPay.Core.SqlTranslate;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Global.Enums;
using DunxPay.Mapping;
using DunxPay.ViewModel.Command.Admin.Module;
using DunxPay.ViewModel.DataSource;
using DunxPay.ViewModel.DunBase.Rbac;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiAuthorize, ApiPermissionFilter]
    public class ModuleController : ApiController
    {
        private readonly IDxModuleService _dxModuleService;
        private readonly IRbacService _rbacService;
        public ModuleController(IDxModuleService dxModuleService, IRbacService rbacService)
        {
            _dxModuleService = dxModuleService;
            _rbacService = rbacService;
        }

        [HttpPost, ApiPermissionFilter(ActionCode = "VIEW")]
        public IHttpActionResult List(ModuleCommand command)
        {
            var prelicateBuilder = PredicateBuilder.Create<DxModule>(null);
            if (!string.IsNullOrEmpty(command.Txtseach))
            {
                switch (command.Field)
                {
                    case "1":
                        prelicateBuilder = prelicateBuilder.And(x => x.ClientName.ToString() == command.Txtseach);
                        break;
                    case "2":
                        prelicateBuilder = prelicateBuilder.And(x => x.Name == command.Txtseach);
                        break;
                    case "3":
                        prelicateBuilder = prelicateBuilder.And(x => x.IdentifyCode.ToString() == command.Txtseach);
                        break;
                }
            }
            if (command.State >= 0)
            {
                switch (command.State)
                {
                    case 1:
                        prelicateBuilder = prelicateBuilder.And(x => x.IsEnabled == true);
                        break;
                    case 2:
                        prelicateBuilder = prelicateBuilder.And(x => x.IsEnabled == false);
                        break;

                }

            }
            var orderby = command.Sort + " " + command.Order;
            var list = _dxModuleService.FindPagedList(prelicateBuilder, orderby, command.Page, command.Rows);
            return Ok(list);
        }
        /// <summary>
        /// 树形加载模块
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public IHttpActionResult TreeList(ModuleCommand command)
        {
            var dxClientId = (int) DxClient.Administrator;
            var menus = _dxModuleService.FindMenusByClientId( dxClientId.ToString()).Select(x => x.ToJsonModel()).ToList();
            var json = menus.BuildTreeMenu();
            return Ok(json);
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "Create")]
        public IHttpActionResult Create(DxModuleViewModel model)
        {
            ModuleIdentifyCodeBuilder moduleIdentifyCodeBuilder = new ModuleIdentifyCodeBuilder();
            model.IdentifyCode = moduleIdentifyCodeBuilder.Build;
            model.CreatedByUserId = UserContext.Id;
            model.CreatedByUserName = UserContext.LoginName;
            model.CreatedOn = DateTime.Now;
            model.IsEnabled = true;
            model.IsDeleted = false;
            model.ParentIdentifyCode = model.ParentIdentifyCode ?? "";
            var entity = model.ToModel();
            entity.Code = model.RequestUrl.Replace("/", "_");
            int a = _dxModuleService.Insert(entity);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a > 0)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "添加成功！";
            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "添加失败！";
            }

            return Ok(dataSourceForm);
        }

        //[HttpGet, ApiPermissionFilter(CheckPermission = false)]
        //public IHttpActionResult Edit(int id)
        //{
        //    var model = _dxModuleService.FindById(id);
        //    var viewmodel = model.ToViewModel();
        //    return Ok(model);
        //}
        [HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Edit(string  id)
        {
            var model = _dxModuleService.FindByClause(x=>x.IdentifyCode==id);
            var viewmodel = model.ToViewModel();
            return Ok(viewmodel);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter( CheckPermission =false, ActionCode = "Edit")]
        public IHttpActionResult Edit(DxModuleViewModel model)
        {
            var oldModel = _dxModuleService.FindById(model.Id);
            oldModel.ClientId = model.ClientId;
            oldModel.ClientName = model.ClientName;
            oldModel.Sort = model.Sort;
            oldModel.Name = model.Name;
            oldModel.RequestUrl = model.RequestUrl;
            oldModel.Icon = model.Icon;
            oldModel.Description = model.Description;
            var entity = model.ToModel();
            entity.Code = model.RequestUrl.Replace("/", "_");
            bool a = _dxModuleService.Update(oldModel);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "修改成功！";
            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "修改失败！";
            }

            return Ok(dataSourceForm);
        }
        /// <summary>
        /// 一键锁定、解锁
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost, ApiPermissionFilter( ActionCode = "Enabled")]
        public IHttpActionResult EnabledOrDisable(UpdateSateCommand command)
        {
            var a = _dxModuleService.UpdateStart(command.SearchState, command.IdList);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "操作成功！";
            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "操作失败！";
            }

            return Ok(dataSourceForm);
        }


    }
}