/**********************************************
文件名：IDxModuleService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块信息表]服务接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Global;

namespace DunxPay.Services.Inter.DunBase
{
    public interface IDxModuleService: IDependency, IService<DxModule>
	{
	    List<MenuQueryModel> FindMenusByClientId(string clientId);
	    bool UpdateStart(int start, string id);

        /// <summary>
        /// 查询模块以及模块操作码集合
        /// </summary>
        /// <param name="ClientId">平台ID</param>
        /// <param name="RoleCode">角色模块标识码</param>
        /// <returns></returns>
        List<ModuleQueryModel> FindModuleListByClientId(int ClientId,string  RoleCode);
    }
}