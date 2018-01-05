using DunxPay.Core.UserManager;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Services.Inter.Rbac;
using System;
using System.Collections.Generic;

namespace DunxPay.Services.Impl.Rbac
{
    public class AdminUserProviderService : IUserProviderService
    {
        #region Implementation of IUserProviderService

        /// <summary>
        /// 根据用户登录名和平台ID查询对应平台的用户数据实体
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <param name="client">平台ID</param>
        /// <returns></returns>
        public UserModel FindByLoginNameAndClientId(string loginName, string client)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户ID查询可用的权限集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="client">平台ID</param>
        /// <param name="isSuperAdmin">是否是超级管理员</param>
        /// <returns></returns>
        public List<PermissionQueryModel> FindPermissions(int userId, string client, bool isSuperAdmin = false)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
