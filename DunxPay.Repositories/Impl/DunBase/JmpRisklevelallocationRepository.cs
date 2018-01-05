/**********************************************
文件名：JmpRisklevelallocationRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[风险等级表]仓储层实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.ViewModel.DunBase.App;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class JmpRisklevelallocationRepository : BaseGenericRepository<JmpRisklevelallocation>, IJmpRisklevelallocationRepository
    {
        public List<RisklevelallocationViewModel> FindRiskLevelByApptypeId(int ApptypeId)
        {
            using (var db = DbFactory.GetConnection)
            {
                var module = @"	select a.r_id,a.r_apptypeid,a.r_risklevel,a.r_state,b.t_name,c.r_name from jmp_risklevelallocation a  left join  jmp_apptype b on a.r_apptypeid = b.t_id left join  jmp_risklevel c on a.r_risklevel = c.r_id where b.t_id=(select t_topid from jmp_apptype  where t_id ="+ApptypeId+" )   order by  r_id desc";
                var entity = db.SqlList<RisklevelallocationViewModel>(string.Format("{0}", module));
                return entity;
            }
        }
    }
}