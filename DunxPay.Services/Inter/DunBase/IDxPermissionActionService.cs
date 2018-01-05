/**********************************************
文件名：IDxPermissionActionService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[权限-操作关系映射表]服务接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Global;

namespace DunxPay.Services.Inter.DunBase
{
	public interface IDxPermissionActionService: IDependency, IService<DxPermissionAction>
	{
        /// <summary>
        /// 批量新增操作码
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
	    bool BatchInsert(List<DxPermissionAction> list);
    }
}