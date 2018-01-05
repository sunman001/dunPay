using DunxPay.Core.SqlTranslate;
using DunxPay.Domain.DunBase;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.Command.Admin.UserManage;
using DunxPay.ViewModel.DataSource;
using DunxPay.ViewModel.DunBase.UserManagement;
using System.Linq;
using System.Web.Http;

namespace DunxPay.ApiServer.Controllers.Api.Admin.v1
{
    public class UserOperateManageController : ApiController
    {
        private readonly IJmpLocuserService _jmpLocuserService;
        public UserOperateManageController(IJmpLocuserService jmpLocuserService)
        {
            _jmpLocuserService = jmpLocuserService;
        }

        /// <summary>
        /// 运营管理展示页
        /// </summary>
        /// <param name="model">传入参数</param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "VIEW")]
        public IHttpActionResult List(OperateCommand model)
        {
            var prelicateBuilder = PredicateBuilder.Create<JmpLocuser>(null);
            if (!string.IsNullOrEmpty(model.SearchKey))
            {
                switch (model.SearchType)
                {
                    case 1:
                        prelicateBuilder = prelicateBuilder.And(x => x.ULoginname == model.SearchKey);
                        break;
                    case 2:
                        prelicateBuilder = prelicateBuilder.And(x => x.URealname == model.SearchKey);
                        break;

                }
            }
            if (model.SearchState > 0)
            {
                switch (model.SearchState)
                {
                    case 1:
                        prelicateBuilder = prelicateBuilder.And(x => x.UState == 1);
                        break;
                    case 2:
                        prelicateBuilder = prelicateBuilder.And(x => x.UState == 0);
                        break;
                }

            }
            var orderby = model.Sort + " " + model.Order;

            var list = _jmpLocuserService.FindPagedList(prelicateBuilder, orderby, model.Page, model.Rows);

            var gridModel = new ViewModel.DataSource.DataSourceResult<JmpLocuser>(list)
            {
                Rows = list.Select(x =>
                {
                    var m = x.ToLocalManagementModel();
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
        public IHttpActionResult EnabledOrDisable(OperateCommand mod)
        {
            var ReturnStart = _jmpLocuserService.UpdateStart(mod.SearchState, mod.IdList);

            return Ok(ReturnStart);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "Create")]
        public IHttpActionResult Create(LocalManagementViewModel model)
        {
            JmpLocuser entity = new JmpLocuser
            {
                URoleId = model.RoleId,
                ULoginname = model.LoginName,
                UPwd = model.Pwd,
                URealname = model.RealName,
                UDepartment = model.Department,
                UPosition = model.Position,
                UCount = 0,
                UState = 1,
                UMobilenumber = model.Mobilenumber,
                UEmailaddress = model.EmailAddress,
                UQq = model.QQ,
                UType = 1

            };

            var start = _jmpLocuserService.Insert(entity);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (start > 0)
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

        /// <summary>
        /// 根据ID查询用户的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, ApiPermissionFilter(CheckPermission = false)]
        public IHttpActionResult Edit(int id)
        {
            var entity = _jmpLocuserService.FindById(id);
            LocalManagementViewModel model = new LocalManagementViewModel
            {
                Id = entity.UId,
                LoginName = entity.ULoginname,
                RealName = entity.URealname,
                Department = entity.UDepartment,
                Position = entity.UPosition,
                Mobilenumber = entity.UMobilenumber,
                QQ = entity.UQq,
                EmailAddress = entity.UEmailaddress,
                Pwd = entity.UPwd,
                RoleId = entity.URoleId

            };
            return Ok(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ApiPermissionFilter(ActionCode = "Edit")]
        public IHttpActionResult Edit(LocalManagementViewModel model)
        {
            var oldModel = _jmpLocuserService.FindById(model.Id);
            oldModel.URoleId = model.RoleId;
            oldModel.ULoginname = model.LoginName;
            oldModel.UPwd = model.Pwd;
            oldModel.URealname = model.RealName;
            oldModel.UDepartment = model.Department;
            oldModel.UPosition = model.Position;
            oldModel.UEmailaddress = model.EmailAddress;
            oldModel.UMobilenumber = model.Mobilenumber;
            oldModel.UQq = model.QQ;
            var start = _jmpLocuserService.Update(oldModel);
            DataSourceForm dataSourceForm = new DataSourceForm();
            if (start)
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

    }
}
