using DunxPay.Domain.QueryModel.Admin.User;
using System.Collections.Generic;

namespace DunxPay.Repositories.Inter.DunBase
{
    public interface IRbacRepository
    {
        /// <summary>
        /// 根据用户ID和平台ID查询用户的菜单集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="clientId">平台ID</param>
        /// <param name="isSuperAdmin">是否是超级管理员</param>
        /// <returns></returns>
        List<MenuQueryModel> FindMenusByUserIdAndClientId(int userId, string clientId, bool isSuperAdmin = false);

        /// <summary>
        /// 根据用户ID查询可用的权限集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="isSuperAdmin">是否是超级管理员</param>
        /// <returns></returns>
        List<PermissionQueryModel> FindPermissions(int userId, bool isSuperAdmin = false);
    }
}
