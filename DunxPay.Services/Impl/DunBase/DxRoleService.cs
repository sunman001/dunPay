/**********************************************
文件名：DxRoleService.cs
作者：dunxingpay.com
日期：2017/11/30
描述：[角色信息表]服务实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class DxRoleService : GenericService<DxRole>, IDxRoleService
    {
        private readonly IDxRoleRepository _repository;
        public DxRoleService(IDxRoleRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool DeleteByIdentityCode(string IdentifyCode)
        {
            return _repository.DeleteByIdentityCode(IdentifyCode);
        }

        public List<RolePermissionQueryModel> FindPerssionByRoleId(int RoleId)
        {
            return _repository.FindPerssionByRoleId(RoleId);
        }

        public bool PermissionSet(bool IsDeteled, List<string> IdentifyCode, List<DxPermission> DxPermission, List<DxPermissionAction> DxPermissionAction)
        {
            return _repository.PermissionSet(IsDeteled, IdentifyCode, DxPermission, DxPermissionAction);
        }

        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool UpdateStart(int start, string id)
        {
            return _repository.UpdateStart(start, id);
        }
    }
}