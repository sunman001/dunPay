/**********************************************
文件名：IDxPermissionActionRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[权限-操作关系映射表]仓储层接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;

namespace DunxPay.Repositories.Inter.DunBase
{
	public interface IDxPermissionActionRepository: IRepository<DxPermissionAction>
	{
	    bool BatchInsert(List<DxPermissionAction> list);
    }
}