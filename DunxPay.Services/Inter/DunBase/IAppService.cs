using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.App;
using DunxPay.Global;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Services.Inter.DunBase
{
  public   interface IAppService: IDependency, IService<jmp_app>
    {
        /// <summary>
        /// 应用列表分页查询
        /// </summary>
        /// <param name="paytype">支付类型</param>
        /// <param name="r_id">风险等级</param>
        /// <param name="platformid">关联平台ID</param>
        /// <param name="auditstate">审核状态</param>
        /// <param name="sea_name">关键字</param>
        /// <param name="type">查询字段</param>
        /// <param name="SelectState">应用状态</param>
        /// <param name="appType">应用类型</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndexs">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        IPagedList<AppQueryModel> FindPagedListBysql( int paytype,int  r_id, int platformid,int  auditstate, string  sea_name, int  type, int  SelectState, int  appType, string orderby, int pageIndexs, int pageSize);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="start">状态</param>
        /// <param name="id">要修改的ID</param>
        /// <returns></returns>
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
        /// 根据APPid查询通道设置信息
        /// </summary>
        /// <param name="AppId">应用ID</param>
        /// <returns></returns>
        List<ApprateViewModel> SelectAppRateByAppId(int AppId);

        /// <summary>
        /// 设置通道费率
        /// </summary>
        /// <param name="id">应用ID</param>
        /// <param name="appratelist">通道费率列表</param>
        /// <returns></returns>
        bool AppRateSetup(int id, List<jmp_apprate> appratelist);

    }
}
