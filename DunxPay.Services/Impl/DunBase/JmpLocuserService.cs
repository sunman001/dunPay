/**********************************************
文件名：JmpLocuserService.cs
作者：dunxingpay.com
日期：2017/11/15
描述：[jmp_locuser]服务实现
**********************************************/

using DunxPay.Domain.DunBase;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class JmpLocuserService : GenericService<JmpLocuser>, IJmpLocuserService
    {
        private readonly IJmpLocuserRepository _repository;
        public JmpLocuserService(IJmpLocuserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 根据登录名查询单条数据
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public JmpLocuser FindByLoginName(string loginName)
	    {
	        return _repository.FindByClause(x => x.ULoginname == loginName);
	    }

        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool UpdateStart(int start, string id)
        {
            return _repository.UpdateStart(start, id);
        }
    }
}