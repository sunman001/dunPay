using System;
using System.Web.Http;
using DunxPay.ApiServer.Util.UserManager;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin.Module;
using DunxPay.ViewModel.DataSource;
using DunxPay.ViewModel.DunBase.Rbac;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    public class ModuleActionController : ApiController
    {  private readonly IDxModuleActionService _dxModuleActionService;
        private readonly IDxBasicsModuleActionService _dxBasicsModuleActionService;

        public ModuleActionController(IDxModuleActionService dxModuleActionService,IDxBasicsModuleActionService dxBasicsModuleActionService)
        {
            _dxModuleActionService = dxModuleActionService;
            _dxBasicsModuleActionService = dxBasicsModuleActionService;
        }
        /// <summary>
        /// 模块操作码列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission=false)]
        public IHttpActionResult List(ModuleActionCommand command  )
        {
            var orderby = command.Sort + " " + command.Order;
            var list = _dxModuleActionService.FindPagedList(x=>x.ModuleIdentifyCode== command.ModuleIdentifyCode,orderby,command.Page,command.Rows);
            return Ok(list);
        }
        /// <summary>
        /// 添加操作码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Create(DxModuleActionViewModel model)
        {
            model.CreatedOn = DateTime.Now;
            model.CreatedByUserId = UserContext.Id;
            model.CreatedBy = UserContext.LoginName;
            model.IsEnabled = true;
            var entity = model.ToModel();
            entity.IsButton = model.IsButton == "true" ? true : false;
            int a = _dxModuleActionService.Insert(entity);
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
        [HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Edit(int id)
        {
            var model = _dxModuleActionService.FindById(id);
            var viewmodel = model.ToViewModel();
            return Ok(viewmodel);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Edit(DxModuleActionViewModel model)
        {
            var oldModel = _dxModuleActionService.FindById(model.Id);
            oldModel.Name = model.Name;
            oldModel.ButtonIcon = model.ButtonIcon;
            oldModel.ButtonType = model.ButtonType;
            oldModel.Code = model.Code;
            oldModel.IsButton = model.IsButton=="on"?true:false;
            oldModel.JsOperatingFunction = model.JsOperatingFunction;
            bool a = _dxModuleActionService.Update(oldModel);
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
       /// 一键解锁
       /// </summary>
       /// <param name="command"></param>
       /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult EnabledOrDisable(UpdateSateCommand command)
        {
            var a = _dxModuleActionService.UpdateStart( command.SearchState,command.IdList);
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

        /// <summary>
        /// 根据ID查找基础操作信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult FindBasicMduleAcionById(int id)
        {
            var model = _dxBasicsModuleActionService.FindById(id);
            return Ok(model);
        }

    }

}
