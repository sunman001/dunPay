/**********************************************
文件名：IJmpUserService.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[jmp_user]服务接口
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.UserManage;
using DunxPay.Global;

namespace DunxPay.Services.Inter.DunBase
{
    public interface IJmpUserService : IDependency, IService<JmpUser>
    {

        /// <summary>
        /// 开发者管理查询列表方法
        /// </summary>
        /// <param name="searchType">查询条件类型</param>
        /// <param name="searchKey">关键字</param>
        /// <param name="searchState">启用禁用状态</param>
        /// <param name="category">认证类型</param>
        /// <param name="relation_type">上级类型</param>
        /// <param name="auditstate">审核状态</param>
        /// <param name="riskM">风控资料</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndexs">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        IPagedList<DeveloperModel> FindPagedListBysql(int searchType, string searchKey, string searchState, string category, string relation_type, string auditstate, string riskM, string orderby, int pageIndexs, int pageSize);

        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        bool UpdateStart(int start, string id);
    }
}