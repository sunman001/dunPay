using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.App;
using DunxPay.Global;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Repositories.Inter.DunBase
{
  public   interface IAppRepository:IRepository<jmp_app>
    {
        /// <summary>
        /// 分页查询应用类型
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndexs">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        IPagedList<AppQueryModel> FindPagedListBysql(string @where, string orderby, int pageIndexs, int pageSize);
        bool UpdateStart(int start, string id);

        /// <summary>
        /// 审核应用
        /// </summary>
        /// <param name="id">应用ID</param>
        /// <param name="start">状态</param>
        /// <param name="rid">风险等级</param>
        /// <param name="name">审核人员</param>
        /// <returns></returns>
        bool Updateauditstate(int id, int start, int rid, string name);

        /// <summary>
        /// 根据应用ID 查询通道费率信息
        /// </summary>
        /// <param name="AppId"></param>
        /// <returns></returns>
        List<ApprateViewModel> SelectAppRateByAppId(int AppId);

        /// <summary>
        /// 设置通道费率
        /// </summary>
        /// <param name="id">应用ID</param>
        /// <param name="appratelist">通道费率列表</param>
        /// <returns></returns>
        bool AppRateSetup(int id,List<jmp_apprate> appratelist);
    }
}
