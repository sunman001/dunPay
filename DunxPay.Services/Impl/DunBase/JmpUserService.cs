/**********************************************
文件名：JmpUserService.cs
作者：dunxingpay.com
日期：2017/12/20
描述：[jmp_user]服务实现
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.UserManage;
using DunxPay.Global;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;
using System.Collections.Generic;

namespace DunxPay.Services.Impl.DunBase
{
    public class JmpUserService : GenericService<JmpUser>, IJmpUserService
    {
        private readonly IJmpUserRepository _repository;
        public JmpUserService(IJmpUserRepository repository) : base(repository)
        {
            _repository = repository;
        }


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
        public IPagedList<DeveloperModel> FindPagedListBysql(int searchType, string searchKey, string searchState, string category, string relation_type, string auditstate, string riskM, string orderby, int pageIndexs, int pageSize)
        {
            var where = new List<string>();

            if (!string.IsNullOrEmpty(searchKey))
            {
                switch (searchType)
                {
                    case 1:
                        where.Add(string.Format("u.u_email like '%{0}%'", searchKey));
                        break;
                    case 2:
                        where.Add(string.Format("u.u_realname like '%{0}%'", searchKey));
                        break;
                    case 3:
                        where.Add(string.Format("u.u_name like '%{0}%'", searchKey));
                        break;
                    case 4:
                        where.Add(string.Format("(i.DisplayName like '%{0}%' or o.DisplayName like '%{0}%')", searchKey));
                        break;
                    case 5:
                        where.Add(string.Format("u.u_id like '%{0}%'", searchKey));
                        break;

                }
            }
            if (!string.IsNullOrEmpty(searchState))
            {
                if (searchState != "-1")
                {
                    where.Add(string.Format("u.u_state={0}", searchState));
                }
            }
            if (!string.IsNullOrEmpty(category))
            {
                where.Add(string.Format("u.u_category={0}", category));
            }
            if (!string.IsNullOrEmpty(relation_type))
            {
                where.Add(string.Format("u.relation_type={0}", relation_type));
            }
            if (!string.IsNullOrEmpty(auditstate))
            {
                where.Add(string.Format("u.u_auditstate={0}", auditstate));
            }
            if (!string.IsNullOrEmpty(riskM))
            {
                switch (riskM)
                {
                    case "0":
                        where.Add(string.Format("IsSignContract=1 and IsRecord=1"));

                        break;
                    case "1":
                        where.Add(string.Format("IsSignContract=0 and IsRecord=0"));
                        break;
                }
            }

            return _repository.FindPagedListBysql(string.Join(" AND ", where), orderby, pageIndexs, pageSize);
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