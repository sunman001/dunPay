using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DunxPay.ApiServer.Util.LogWriter;
using DunxPay.ApiServer.Util.UserManager;
using DunxPay.Domain.QueryModel.Admin.App;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin.App;
using DunxPay.ViewModel.Command.Admin.Module;
using DunxPay.ViewModel.DataSource;
using DunxPay.ViewModel.DunBase.App;
using DunxPay.Core;
using DunxPay.Core.Extensions;
using DunxPay.LogCenter.Extensions;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiAuthorize, ApiPermissionFilter]
    public class AppController : ApiController
    {
        private readonly IAppService _iAppService;
        private readonly IPaymodeService _iPaymodeService;
        private readonly IAdminLogFactory _logFactory;
        public AppController(IAppService appService, IPaymodeService iPaymodeService, IAdminLogFactory logFactory)
        {
            _iAppService = appService;
            _iPaymodeService = iPaymodeService;
            _logFactory = logFactory;
        }

        /// <summary>
        /// 应用查询列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public IHttpActionResult List(AppCommand command)
        {
            int selectState = string.IsNullOrEmpty(command.SelectState) ? 1 : Int32.Parse(command.SelectState);//状态
            int auditstate = string.IsNullOrEmpty(command.Auditstate) ? -1 : Int32.Parse(command.Auditstate);//审核状态
            int type = string.IsNullOrEmpty(command.Type) ? 0 : Int32.Parse(command.Type);//查询条件选择
            string seaname = string.IsNullOrEmpty(command.SeaName) ? "" : command.SeaName;//查询条件内容
            int platformid = string.IsNullOrEmpty(command.Platformid) ? 0 : Int32.Parse(command.Platformid);//关联平台
            int appType = string.IsNullOrEmpty(command.AppType) ? 0 : int.Parse(command.AppType); //所属应用类型	
            int rid = string.IsNullOrEmpty(command.Rid) ? 0 : int.Parse(command.Rid); //风险等级	
            int paytype = string.IsNullOrEmpty(command.Paytype) ? 0 : int.Parse(command.Paytype); //支付类型
            var orderby = "order by" + " " + command.Sort + " " + command.Order;
            var list = _iAppService.FindPagedListBysql(paytype, rid, platformid, auditstate, seaname, type, selectState,
                appType, orderby, command.Page, command.Rows);
            var gridModel = new ViewModel.DataSource.DataSourceResult<AppQueryModel>(list)
            {
                Rows = list.Select(x =>
                {
                    var m = x;
                    return x;
                })
            };
            return Ok(gridModel);
        }

        /// <summary>
        /// 一键锁定、解锁
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [System.Web.Http.HttpPost, ApiPermissionFilter(ActionCode = "Enabled")]
        public IHttpActionResult EnabledOrDisable(UpdateSateCommand command)
        {
            var a = _iAppService.UpdateStart(command.SearchState, command.IdList);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "操作成功！";
                _logFactory.Logger.OperateLog("一键启用或者禁用应用","操作人员"+ UserContext.LoginName + ",应用ID为"+command.IdList+"");
            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "操作失败！";
            }

            return Ok(dataSourceForm);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, ApiPermissionFilter(ActionCode = "Create")]
        public IHttpActionResult Create(AppViewModel model)
        {
            var entity = model.ToModel();
            entity.a_time = DateTime.Now;
            entity.a_state = 1;
            entity.a_rid = 0;
            entity.a_key = "";
            entity.a_secretkey = ""; 
            var a = _iAppService.Insert(entity);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a > 0)
            {
                entity.a_key = DesEncrypt.Encrypt(entity.a_user_id + ";" + a + ";" + DateTime.Now.ToString("yyyyMMddssmmfff"));
                entity.a_secretkey = DesEncrypt.Encrypt(a + ";" + entity.a_key + ";" + DateTime.Now.ToString("yyyyMMddssmmfff"));
                entity.a_id = a;
                if (_iAppService.Update(entity))
                {
                    dataSourceForm.IsSuccess = true;
                    dataSourceForm.Message = "添加成功！";
                    _logFactory.Logger.CreateLog("新增应用", entity);
                }

            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "添加失败！";
            }
            return Ok(dataSourceForm);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Edit(int id)
        {
            var model = _iAppService.FindById(id);
            var viewmodel = model.ToViewModel();
            return Ok(viewmodel);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, ApiPermissionFilter(ActionCode = "Edit")]
        public IHttpActionResult Edit(AppViewModel model)
        {
            var entity = model.ToModel();
            var oldmodel = _iAppService.FindById(entity.a_id);
            var modclone = oldmodel.Clone();
            oldmodel.a_name = entity.a_name;
            oldmodel.a_appsynopsis = entity.a_appsynopsis;
            oldmodel.a_appurl = entity.a_appurl;
            oldmodel.a_notifyurl = entity.a_notifyurl;
            oldmodel.a_paymode_id = entity.a_paymode_id;
            oldmodel.a_apptype_id = entity.a_apptype_id;
            oldmodel.a_showurl = entity.a_showurl;
            oldmodel.a_user_id = entity.a_user_id;
            oldmodel.a_platform_id = entity.a_platform_id;
            var a = _iAppService.Update(oldmodel);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "修改成功！";
                _logFactory.Logger.ModifyLog("修改应用",modclone,entity);
            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "修改失败！";
            }
            return Ok(dataSourceForm);
        }

        /// <summary>
        /// 获取可用的支付类型
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult GetPayModeList()
        {
            var List = _iPaymodeService.FindListByClause(x => x.p_state == 1);
            return Ok(List);
        }
        /// <summary>
        /// 审核应用
        /// </summary>
        /// <param name="auditing"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, ApiPermissionFilter(ActionCode = "Auditing")]
        public IHttpActionResult AppAuditing(AppAuditing auditing)
        {
           
            int auditstate = string.IsNullOrEmpty(auditing.State) ? 0 : int.Parse(auditing.State);
            string name = UserContext.LoginName;
            var a = _iAppService.Updateauditstate(auditing.Id, auditstate, auditing.Rid, name);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "审核成功！";
                _logFactory.Logger.OperateLog("审核应用","审核应用的ID是"+auditing.Id+",审核状态为"+auditstate+",审核人员是"+name+"");
            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "审核失败！";
            }
            return Ok(dataSourceForm);
        }
        /// <summary>
        /// 通道费率设置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [System.Web.Http.HttpGet, ApiPermissionFilter(CheckPermission=false)]
        public IHttpActionResult AppRate(int id)
        {
            var list = _iAppService.SelectAppRateByAppId(id);
            return Ok(list);
        }
        [System.Web.Http.HttpPost, ApiPermissionFilter(ActionCode = "AppRate")]
        public IHttpActionResult AppRateSetup(AppRateSetupCommand AppRateModel)
        {
            foreach (var apprate in AppRateModel.AppRateList)
            {
                apprate.r_name= UserContext.LoginName;
                apprate.r_time = DateTime.Now;
                apprate.r_appid = AppRateModel.Id;
            }
            var a = _iAppService.AppRateSetup(AppRateModel.Id,AppRateModel.AppRateList);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (a)
            {
                dataSourceForm.IsSuccess = true;
                dataSourceForm.Message = "通道费率设置成功！";
                _logFactory.Logger.OperateLog("应用通道费率设置", "设置应用的ID是" + AppRateModel.Id + ",设置的人员是" + UserContext.LoginName + "");
            }
            else
            {
                dataSourceForm.IsSuccess = false;
                dataSourceForm.Message = "通道费率设置成功！";
            }
            return Ok(dataSourceForm);
           
        }
    }
}
