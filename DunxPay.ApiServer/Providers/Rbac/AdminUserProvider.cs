using DunxPay.Core.UserManager;
using DunxPay.Global.Enums;
using DunxPay.Services.Inter.DunBase;
using System.Web.Mvc;

namespace DunxPay.ApiServer.Providers.Rbac
{
    /// <summary>
    /// 运营平台用户信息提供者实现类
    /// </summary>
    public class AdminUserProvider : UserProvider
    {
        private string _clientId = "1";
        #region Overrides of UserProvider

        /// <summary>
        /// 平台ID
        /// </summary>
        public override string ClientId { get { return _clientId; } protected set { _clientId = value; } }

        /// <summary>
        /// 根据用户查询用户信息实体
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <param name="clientId">平台ID</param>
        /// <returns></returns>
        public override UserModel FindByLoginName(string loginName, string clientId)
        {
            _clientId = clientId;
            var userService = DependencyResolver.Current.GetService<IJmpLocuserService>();
            var userEntity = userService.FindByLoginName(loginName);
            var userModel = new UserModel
            {
                Department = userEntity.UDepartment,
                Id = userEntity.UId,
                LoginName = userEntity.ULoginname,
                RealName = userEntity.URealname,
                Type = userEntity.UType ?? (int)UserType.GeneralUser,
                ClientId = ClientId
            };
            return userModel;
        }

        #endregion
    }
}