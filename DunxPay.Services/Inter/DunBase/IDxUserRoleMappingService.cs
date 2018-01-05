/**********************************************
文件名：IDxUserRoleMappingService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[用户-角色关系映射表]服务接口
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Global;

namespace DunxPay.Services.Inter.DunBase
{
	public interface IDxUserRoleMappingService: IDependency, IService<DxUserRoleMapping>
	{
	}
}