using AutoMapper;
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
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {

                #region User
                cfg.CreateMap<JmpLocuser, LocalUserViewModel>()
                    .ForMember(d => d.Type, d => d.MapFrom(s => s.UType))
                    .ForMember(d => d.LoginName, d => d.MapFrom(s => s.ULoginname))
                    .ForMember(d => d.Password, d => d.MapFrom(s => s.UPwd))
                    .ForMember(d => d.State, d => d.MapFrom(s => s.UState))
                    .ForMember(d => d.EmailAddress, d => d.MapFrom(s => s.UEmailaddress))
                    .ForMember(d => d.Id, d => d.MapFrom(s => s.UId))
                    .ForMember(d => d.LoginCount, d => d.MapFrom(s => s.UCount))
                    .ForMember(d => d.RealName, d => d.MapFrom(s => s.URealname))
                ;
                cfg.CreateMap<LocalUserViewModel, JmpLocuser>();
                #endregion
                #region App
                cfg.CreateMap<jmp_app, AppViewModel>();
                cfg.CreateMap<AppViewModel, jmp_app>();
                #endregion
                #region Menu
                cfg.CreateMap<DxModuleViewModel, DxModule>();
                cfg.CreateMap<DxModule, DxModuleViewModel>();
                cfg.CreateMap<MenuQueryModel, MenuViewModel>();
                cfg.CreateMap<MenuQueryModel, MenuJsonModel>()
                    .ForMember(d => d.Id, d => d.MapFrom(s => s.IdentifyCode))
                    .ForMember(d => d.Text, d => d.MapFrom(s => s.Name))
                    .ForMember(d => d.IconCls, d => d.MapFrom(s => s.Icon));
                #endregion

                #region logger
                cfg.CreateMap<DxAdminOperationLog, DxAdminOperationLogViewModel>();
                #endregion
                #region 权限模块操作码
                cfg.CreateMap<DxModuleActionViewModel, DxModuleAction>();
                cfg.CreateMap<DxModuleAction, DxModuleActionViewModel>()
                     .ForMember(d => d.IsButton, d => d.MapFrom(s => s.IsButton == true ? "on" : "off"));

                #endregion

                #region UserLocalManagement

                cfg.CreateMap<JmpLocuser, LocalManagementViewModel>()
                    .ForMember(d => d.LoginName, d => d.MapFrom(s => s.ULoginname))
                    .ForMember(d => d.State, d => d.MapFrom(s => s.UState))
                    .ForMember(d => d.EmailAddress, d => d.MapFrom(s => s.UEmailaddress))
                    .ForMember(d => d.Id, d => d.MapFrom(s => s.UId))
                    .ForMember(d => d.LoginCount, d => d.MapFrom(s => s.UCount))
                    .ForMember(d => d.RealName, d => d.MapFrom(s => s.URealname))
                    .ForMember(d => d.Department, d => d.MapFrom(s => s.UDepartment))
                    .ForMember(d => d.Position, d => d.MapFrom(s => s.UPosition))
                    .ForMember(d => d.Mobilenumber, d => d.MapFrom(s => s.UMobilenumber))
                    .ForMember(d => d.QQ, d => d.MapFrom(s => s.UQq))
                    .ForMember(d => d.Pwd, d => d.MapFrom(s => s.UPwd))
                    .ForMember(d => d.RoleId, d => d.MapFrom(s => s.URoleId))
                    ;


                #endregion

                #region RoleManagement

                cfg.CreateMap<DxRole, DxRoleViewModel>();
                cfg.CreateMap<DxRoleViewModel, DxRole>();
                #endregion

                #region 开发者表

                cfg.CreateMap<DeveloperModel, DeveloperViewModel>();
                cfg.CreateMap<DeveloperViewModel, DeveloperModel>();

                #endregion

            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}