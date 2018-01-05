using DunxPay.Core.UserManager;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Global;
using System.Collections.Generic;

namespace DunxPay.Services.Inter.Rbac
{
    /// <summary>
    /// 用户信息提供接口
    /// </summary>
    public interface IUserProviderService : IDependency
    {
        /// <summary>
        /// 根据用户登录名和平台ID查询对应平台的用户数据实体
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <param name="client">平台ID</param>
        /// <returns></returns>
        UserModel FindByLoginNameAndClientId(string loginName,string client);

        /// <summary>
        /// 根据用户ID查询可用的权限集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="client">平台ID</param>
        /// <param name="isSuperAdmin">是否是超级管理员</param>
        /// <returns></returns>
        List<PermissionQueryModel> FindPermissions(int userId,string client, bool isSuperAdmin = false);
    }
}
