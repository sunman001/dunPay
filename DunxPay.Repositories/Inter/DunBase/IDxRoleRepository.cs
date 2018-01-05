/**********************************************
文件名：IDxRoleRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[角色信息表]仓储层接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;

namespace DunxPay.Repositories.Inter.DunBase
{
	public interface IDxRoleRepository: IRepository<DxRole>
	{
        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        bool UpdateStart(int start, string id);

	    List<RolePermissionQueryModel> FindPerssionByRoleId(int RoleId);
        /// <summary>
        /// 权限编号
        /// </summary>
        /// <param name="IdentifyCode"></param>
        /// <returns></returns>
	    bool DeleteByIdentityCode(string  IdentifyCode);

        /// <summary>
        /// 权限设置
        /// </summary>
        /// <param name="IsDeteled"> 是否删除</param>
        /// <param name="IdentifyCode">删除权限的标识码</param>
        /// <param name="DxPermission"></param>
        /// <param name="DxPermissionAction"></param>
        /// <returns></returns>
	    bool PermissionSet(bool IsDeteled, List<string> IdentifyCode, List< DxPermission> DxPermission,List<DxPermissionAction> DxPermissionAction);


	}
}