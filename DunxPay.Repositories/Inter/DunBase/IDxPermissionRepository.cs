/**********************************************
文件名：IDxPermissionRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块-角色关系映射表]仓储层接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;

namespace DunxPay.Repositories.Inter.DunBase
{
	public interface IDxPermissionRepository: IRepository<DxPermission>
	{
	    bool BatchInsert(List<DxPermission> list);
    }
}