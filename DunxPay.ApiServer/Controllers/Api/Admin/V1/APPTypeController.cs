using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DunxPay.Domain.DunBase;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin.App;
using DunxPay.ViewModel.DataSource;
using DunxPay.ViewModel.DunBase.App;
using DunxPay.ViewModel.Command.Admin.Module;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    [ApiAuthorize, ApiPermissionFilter]
    public class AppTypeController : ApiController
    {
        private readonly IAppTypeService _iAppTypeService;
        public AppTypeController(IAppTypeService iAppTypeService)
        {
            _iAppTypeService = iAppTypeService;
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "VIEW")]
        public IHttpActionResult List(AppTypeCommand command)
        {
            var orderby = "order by" + " " + command.Sort + " " + command.Order;
            int state = !string.IsNullOrEmpty(command.State) ? int.Parse(command.State) : -1;
            int pid = !string.IsNullOrEmpty(command.Pid) ? int.Parse(command.Pid) : -1;
            var list = _iAppTypeService.FindPagedListBysql(pid, command.Keyword, command.Type, state, orderby, command.Page, command.Rows);
            var gridModel = new ViewModel.DataSource.DataSourceResult<AppTypeViewModel>(list)
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
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "Create")]
        public IHttpActionResult Create(AppTypeViewModel model)
        {
            jmp_apptype entity = new jmp_apptype
            {
               t_topid = model.ParentId,
               t_name = model.Name,
               t_sort = model.Sort,
               t_state = 1
            };
            var a = _iAppTypeService.Insert(entity);
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
            var entity = _iAppTypeService.FindById(id);
            AppTypeViewModel model = new AppTypeViewModel
            {
                Id=entity.t_id,
                Name=entity.t_name,
                Sort = entity.t_sort,
                ParentId = entity.t_topid
            };
            return Ok(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "Edit")]
        public IHttpActionResult Edit(AppTypeViewModel model)
        {
            var oldModel = _iAppTypeService.FindById(model.Id);
            oldModel.t_name = model.Name;
            oldModel.t_sort = model.Sort;
            oldModel.t_topid = model.ParentId;
            var a = _iAppTypeService.Update( oldModel);
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

        [HttpPost, ApiPermissionFilter(ActionCode = "Enabled")]
        public IHttpActionResult EnabledOrDisable(UpdateSateCommand command)
        {
            var a = _iAppTypeService.UpdateStart(command.SearchState, command.IdList);
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
