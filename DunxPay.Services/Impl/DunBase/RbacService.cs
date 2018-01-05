using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Global;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;
using System.Collections.Generic;

namespace DunxPay.Services.Impl.DunBase
{
    public class RbacService :IRbacService,IDependency
    {
        private readonly IRbacRepository _repository;
        public RbacService(IRbacRepository repository)
        {
            _repository = repository;
        }
        #region Implementation of IRbacService

        /// <summary>
        /// 根据用户ID和平台ID查询用户的菜单集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="clientId">平台ID</param>
        /// <returns></returns>
        public List<MenuQueryModel> FindMenusByUserIdAndClientId(int userId, string clientId,bool isSuperAdmin = false)
        {
            return _repository.FindMenusByUserIdAndClientId(userId, clientId, isSuperAdmin);
        }

        /// <summary>
        /// 根据用户ID查询可用的权限集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="isSuperAdmin">是否是超级管理员</param>
        /// <returns></returns>
        public List<PermissionQueryModel> FindPermissions(int userId, bool isSuperAdmin = false)
        {
            return _repository.FindPermissions(userId, isSuperAdmin);
        }

        #endregion
    }
}