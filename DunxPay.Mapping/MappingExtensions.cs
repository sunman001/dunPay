using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Domain.QueryModel.Admin.UserManage;
using DunxPay.ViewModel;
using DunxPay.ViewModel.DunBase.App;
using DunxPay.ViewModel.DunBase.Logger;
using DunxPay.ViewModel.DunBase.Rbac;
using DunxPay.ViewModel.DunBase.RoleManagement;
using DunxPay.ViewModel.DunBase.UserManagement;

namespace DunxPay.Mapping
{
    /// <summary>
    /// 数据库表-实体映射静态扩展类
    /// </summary>
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region JmpLocuser

        public static LocalUserViewModel ToModel(this JmpLocuser entity)
        {
            return entity.MapTo<JmpLocuser, LocalUserViewModel>();
        }

        public static JmpLocuser ToEntity(this LocalUserViewModel model)
        {
            return model.MapTo<LocalUserViewModel, JmpLocuser>();
        }

        public static LocalManagementViewModel ToLocalManagementModel(this JmpLocuser entity)
        {
            return entity.MapTo<JmpLocuser, LocalManagementViewModel>();
        }

        #endregion
        #region DxModuleAction
        public static DxModuleAction ToModel(this DxModuleActionViewModel entity)
        {
            return entity.MapTo<DxModuleActionViewModel, DxModuleAction>();
        }
        public static DxModuleActionViewModel ToViewModel(this DxModuleAction entity)
        {
            return entity.MapTo<DxModuleAction, DxModuleActionViewModel>();
        }
        #endregion


        #region 应用

        public static jmp_app ToModel(this AppViewModel entity)
        {
            return entity.MapTo<AppViewModel, jmp_app>();
        }
        public static AppViewModel ToViewModel(this jmp_app entity)
        {
            return entity.MapTo<jmp_app, AppViewModel>();
        }
        #endregion
        #region Menu
        public static MenuViewModel ToModel(this MenuQueryModel entity)
        {
            return entity.MapTo<MenuQueryModel, MenuViewModel>();
        }

        public static MenuJsonModel ToJsonModel(this MenuQueryModel entity)
        {
            return entity.MapTo<MenuQueryModel, MenuJsonModel>();
        }
        public static DxModule ToModel(this DxModuleViewModel entity)
        {
            return entity.MapTo<DxModuleViewModel, DxModule>();
        }
        public static DxModuleViewModel ToViewModel(this DxModule entity)
        {
            return entity.MapTo<DxModule, DxModuleViewModel>();
        }

        #endregion

        #region Logger

        public static DxAdminOperationLogViewModel ToModel(this DxAdminOperationLog entity)
        {
            return entity.MapTo<DxAdminOperationLog, DxAdminOperationLogViewModel>();
        }
        #endregion

        #region dxrole

        public static DxRoleViewModel ToModel(this DxRole entity)
        {
            return entity.MapTo<DxRole, DxRoleViewModel>();
        }
        public static DxRole ToEntity(this DxRoleViewModel entity)
        {
            return entity.MapTo<DxRoleViewModel, DxRole>();
        }
        #endregion

        #region DeveloperManage

        public static DeveloperViewModel ToModel(this DeveloperModel entity)
        {
            return entity.MapTo<DeveloperModel, DeveloperViewModel>();
        }

        public static DeveloperModel ToEntity(this DeveloperViewModel entity)
        {
            return entity.MapTo<DeveloperViewModel, DeveloperModel>();
        }

        #endregion

    }
}