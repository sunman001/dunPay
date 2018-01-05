/**********************************************
文件名：JmpUserRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[jmp_user]仓储层实现
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.UserManage;
using DunxPay.Global;
using DunxPay.Repositories.Inter.DunBase;
using ServiceStack.OrmLite;
using System.Text;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class JmpUserRepository : BaseGenericRepository<JmpUser>, IJmpUserRepository
    {
        /// <summary>
        /// 开发者管理查询列表方法
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndexs">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        public IPagedList<DeveloperModel> FindPagedListBysql(string where, string orderby, int pageIndexs, int pageSize)
        {
            var sql = new StringBuilder();
            sql.AppendFormat(@"
select  u.IsSignContract,u.IsRecord, u.u_id,relation_type,u.u_category,u.u_idnumber,u.u_photo,u.u_blicense,u.u_blicensenumber,
u.u_count,u.u_state,u.u_auditstate,u.u_topid,u.u_address,u.u_email,u.u_role_id,u.u_password,u.u_realname,u.u_phone,u.u_qq,u.u_bankname,
u.u_name,u.u_account,u.u_time,u.u_auditor,u.IsSpecialApproval,u.SpecialApproval,i.DisplayName as BusinessName,o.DisplayName as AgentName
 from jmp_user as u 
 left join 
 CoBusinessPersonnel as i 
 on u.relation_person_id = i.Id and u.relation_type = 1 
 left join 
 CoAgent as o 
 on u.relation_person_id = o.Id and u.relation_type = 2 
");
            if (!string.IsNullOrEmpty(@where))
            {
                sql.AppendFormat(" WHERE {0}", @where);
            }
            var list = ExecuteProc<DeveloperModel>(sql.ToString(), orderby, pageIndexs, pageSize);
            return list;
        }

        /// <summary>
        /// 一键启用or禁用
        /// </summary>
        /// <param name="start">状态</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool UpdateStart(int start, string id)
        {
            using (var db = DbFactory.GetConnection)
            {
                var sql = @"update jmp_user set u_state=@start where u_id in (" + id + ") ";

                int num = db.ExecuteSql(sql, new { start = start });

                if (num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}