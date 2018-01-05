/**********************************************
文件名：IDxPermissionService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块-角色关系映射表]服务接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Global;

namespace DunxPay.Services.Inter.DunBase
{
	public interface IDxPermissionService: IDependency, IService<DxPermission>
	{
        /// <summary>
        /// 批量修改操作码
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
	    bool BatchInsert(List<DxPermission> list);
    }
}