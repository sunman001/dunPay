/**********************************************
文件名：IJmpUserRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[jmp_user]仓储层接口
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.UserManage;
using DunxPay.Global;

namespace DunxPay.Repositories.Inter.DunBase
{
	public interface IJmpUserRepository: IRepository<JmpUser>
	{

        /// <summary>
        /// 开发者管理查询列表方法
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndexs">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        IPagedList<DeveloperModel> FindPagedListBysql(string @where, string orderby, int pageIndexs, int pageSize);


        /// <summary>
        /// 一键启用or禁用
        /// </summary>
        /// <param name="start">状态</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool UpdateStart(int start, string id);
    }
}