/**********************************************
文件名：IDxModuleActionService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块-操作信息表]服务接口
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Global;

namespace DunxPay.Services.Inter.DunBase
{
	public interface IDxModuleActionService: IDependency, IService<DxModuleAction>
	{
	    bool UpdateStart(int start, string id);

	}
}