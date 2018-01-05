/**********************************************
文件名：IDxModuleActionRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块-操作信息表]仓储层接口
**********************************************/
using DunxPay.Domain.DunBase;

namespace DunxPay.Repositories.Inter.DunBase
{
	public interface IDxModuleActionRepository: IRepository<DxModuleAction>
	{
	    bool UpdateStart(int start, string id);

	}
}