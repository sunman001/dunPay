/**********************************************
文件名：DxModuleRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块信息表]仓储层实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Repositories.Inter.DunBase;
using Infrastructure;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class DxModuleRepository : BaseGenericRepository<DxModule>, IDxModuleRepository
    {
        private readonly AbstractDbConnectionFactory _dbFactory = new BaseDbConnectionFactory();

        public List<MenuQueryModel> FindMenusByClientId(string clientId)
        {
            using (var db = _dbFactory.GetConnection)
            {
                var module = @"	SELECT * FROM dbo.DxModule AS M  where ClientId="+ clientId + "";
                var entity = db.SqlList<MenuQueryModel>(string.Format("{0}", module));
                return entity;
            }
        }

        public List<ModuleQueryModel> FindModuleListByClientId(int ClientId,string  RoleId)
        {
            using (var db = _dbFactory.GetConnection)
            {
                var entity = db.SqlList<ModuleQueryModel>(string.Format(@" ;WITH  T as (
                  SELECT M.IdentifyCode,M.ParentIdentifyCode,M.Name,A.Name AS ModuleActionName ,A.Code FROM dbo.DxModule AS M  
                  left join  DxModuleAction AS  A  ON M.IdentifyCode=A.ModuleIdentifyCode
				  where  M.ClientId={0} ),
				  T1 as (select a.ModuleIdentifyCode,b.Code from DxPermission a  left join DxPermissionAction b on a.IdentifyCode=b.PermissionIdentifyCode where RoleIdentifyCode='{1}'),
        t2 as ( select t.* ,(CASE WHEN t1.Code IS NOT NULL THEN 1 ELSE 0 END) AS Checked  from T  left join T1 on t.IdentifyCode=t1.ModuleIdentifyCode and t.code=t1.Code)
	  select * from t2 ", ClientId,RoleId ));
                return entity;
            }
        }



        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool UpdateStart(int start, string id)
        {
            id =id.Contains(",")?"'"+ id.Replace(",", "','")+"'":"'"+id+"'";

            using (var db = DbFactory.GetConnection)
            {
                var sql = @"update DxModule set IsEnabled=@start where  IdentifyCode in(" + id + ") ";

                int num = db.ExecuteSql(sql, new {start = start});

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
