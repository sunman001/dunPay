/**********************************************
文件名：IJmpLocuserRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[jmp_locuser]仓储层接口
**********************************************/

using DunxPay.Domain.DunBase;

namespace DunxPay.Repositories.Inter.DunBase
{
    public interface IJmpLocuserRepository: IRepository<JmpLocuser>
	{
        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        bool UpdateStart(int start, string id);
    }
}