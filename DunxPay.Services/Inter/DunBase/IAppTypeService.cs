/**********************************************
文件名：IDxPermissionService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块-角色关系映射表]服务接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Global;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Services.Inter.DunBase
{
	public interface IAppTypeService : IDependency, IService<jmp_apptype>
	{
        /// <summary>
        /// 分页查询应用类型列表
        /// </summary>
        /// <param name="pid">所属应用类型ID</param>
        /// <param name="keyword">关键字</param>
        /// <param name="type">查询类型字段</param>
        /// <param name="state">状态</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndexs"> 当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
	    IPagedList<AppTypeViewModel> FindPagedListBysql(int pid, string keyword, string type, int state, string orderby, int pageIndexs, int pageSize);

	    bool UpdateStart(int start, string id);

	    /// <summary>
	    /// 查询正在用的应用类型
	    /// </summary>
	    /// <returns></returns>
	    List<jmp_apptype> FindListByPay();
    }
}