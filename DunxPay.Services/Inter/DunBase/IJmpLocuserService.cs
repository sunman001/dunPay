/**********************************************
文件名：IJmpLocuserService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[jmp_locuser]服务接口
**********************************************/

using DunxPay.Domain.DunBase;

namespace DunxPay.Services.Inter.DunBase
{
    public interface IJmpLocuserService: IService<JmpLocuser>
	{
	    /// <summary>
	    /// 根据登录名查询单条数据
	    /// </summary>
	    /// <param name="loginName">登录名</param>
	    /// <returns></returns>
	    JmpLocuser FindByLoginName(string loginName);

        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        bool UpdateStart(int start, string id);

    }
}