using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.App;
using DunxPay.Global;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.ViewModel.DunBase.App;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class AppRepository : BaseGenericRepository<jmp_app>, IAppRepository
    {
        public bool AppRateSetup(int id, List<jmp_apprate> appratelist)
        {

            using (var db = DbFactory.GetConnection)
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        if (id>0)
                        {
                            //删除原有的通道信息
                            var sql = @"delete from jmp_apprate where  r_appid=" + id + "";
                             db.ExecuteSql(sql);
                        }
                        //添加通道费率信息
                        if (appratelist.Count > 0)
                        {
                            db.InsertAll(appratelist);
                        }
                        
                        trans.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        return false;
                    }

                }
            }
        }

        public IPagedList<AppQueryModel> FindPagedListBysql(string where, string orderby, int pageIndexs, int pageSize)
        {
            var sql = new StringBuilder();
            sql.AppendFormat(@"select a.a_id, a.a_auditstate, a.a_secretkey, a.a_time, a.a_user_id, a.a_name, a.a_platform_id,a.a_paymode_id, a.a_apptype_id, a.a_notifyurl, a.a_showurl, a.a_auditor, 
          a.a_key, a.a_state, b.u_email, b.u_realname, typeapp.t_name,d.r_id ,d.r_name 
          from JMP_APP a  left join JMP_USER b on a.a_user_id = b.u_id
          inner join jmp_apptype apptype on apptype.t_id = a.a_apptype_id 
          inner join jmp_apptype typeapp on typeapp.t_id = apptype.t_topid 
          left join jmp_risklevelallocation c on c.r_id = a.a_rid 
          left join jmp_risklevel d on d.r_id = c.r_risklevel");
            if (!string.IsNullOrEmpty(@where))
            {
                sql.AppendFormat(" WHERE {0}", @where);
            }
            var list = ExecuteProc<AppQueryModel>(sql.ToString(), orderby, pageIndexs, pageSize);
            return list;
        }
        /// <summary>
        /// 根据应用ID查询通道费率设置
        /// </summary>
        /// <param name="AppId">应用id</param>
        /// <returns></returns>
        public List<ApprateViewModel> SelectAppRateByAppId(int AppId)
        {
            using (var db = DbFactory.GetConnection)
            {
                var sql = "WITH t AS (SELECT * FROM jmp_apprate AS r WHERE r.r_appid ="+AppId+" )SELECT a.p_id,a.p_name,ISNULL(t.r_proportion, 0) AS r_proportion, ISNULL(t.r_paymodeid, 0) AS r_paymodeid FROM jmp_paymode as a LEFT JOIN t ON a.p_id = T.r_paymodeid ";
                var entity = db.SqlList<ApprateViewModel>(sql);
                return entity;
            }
        }

        /// <summary>
        /// 审核应用
        /// </summary>
        /// <param name="id">应用ID</param>
        /// <param name="start">审核状态</param>
        /// <param name="rid">风险等级</param>
        /// <param name="name">审核人员</param>
        /// <returns></returns>
        public bool Updateauditstate(int id, int start, int rid, string name)
        {
            using (var db = DbFactory.GetConnection)
            {
                var sql = @"update jmp_app set a_auditstate=" + start + ",a_rid=" + rid + ",a_auditor='" + name + "' where a_id=" + id + " ";

                int num = db.ExecuteSql(sql);
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
        /// <summary>
        /// 一键启用、禁用
        /// </summary>
        /// <param name="start">状态</param>
        /// <param name="id">应用Id</param>
        /// <returns></returns>
        public bool UpdateStart(int start, string id)
        {
            using (var db = DbFactory.GetConnection)
            {
                var sql = @"update jmp_app set a_state=@start where  a_id in(" + id + ") ";

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
