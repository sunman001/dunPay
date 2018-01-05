/**********************************************
文件名：IDxModuleRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块信息表]仓储层接口
**********************************************/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Global;

namespace DunxPay.Repositories.Inter.DunBase
{
	public interface IDxModuleRepository: IRepository<DxModule>
	{
	    List<MenuQueryModel> FindMenusByClientId(string clientId);

	    bool UpdateStart(int start, string id);

	    /// <summary>
	    /// 查询模块以及模块操作码集合
	    /// </summary>
	    /// <param name="ClientId"></param>
	    List<ModuleQueryModel> FindModuleListByClientId(int ClientId,string  RoleId);
	}
}