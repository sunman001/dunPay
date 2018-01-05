using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DunxPay.Domain.DunBase;
using DunxPay.Global;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.ViewModel.DunBase.App;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class AppTypeRepository : BaseGenericRepository<jmp_apptype>, IAppTypeRepository
    {
        public List<jmp_apptype> FindListByPay()
        {
            using (var db = DbFactory.GetConnection)
            {
                var sql = "select * from jmp_apptype  where t_id in (select  DISTINCT(t_topid) from jmp_apptype where t_topid in( select t_id from jmp_apptype where t_topid='0'   )) and t_state='1' order by t_sort desc";
                var entity = db.SqlList<jmp_apptype >(sql);
                return entity;
            }
        }

        public IPagedList<AppTypeViewModel> FindPagedListBysql(string @where, string orderby, int pageIndexs, int pageSize)
        {
            var  sql = new StringBuilder();
            sql.AppendFormat(@" select a.t_id as Id ,a.t_name as Name,a.t_sort as Sort,a.t_topid as ParentId,a.t_state as State,  isnull(b.t_name,'父级')as ParentName from  JMP_APPTYPE  a  left join JMP_APPTYPE b on a.t_topid=b.t_id");
            if (!string.IsNullOrEmpty(@where))
            {
                sql.AppendFormat(" WHERE {0}", @where);
            }
          var list=  ExecuteProc<AppTypeViewModel>(sql.ToString(),orderby,pageIndexs,pageSize);
          return list;



        }

        public bool UpdateStart(int start, string id)
        {
            using (var db = DbFactory.GetConnection)
            {
                var sql = @"update jmp_apptype set t_state=@start where  t_id in(" + id + ") ";

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
