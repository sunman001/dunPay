using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.App;
using DunxPay.Global;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Services.Impl.DunBase
{
    public class AppService : GenericService<jmp_app>, IAppService
    {
        private readonly IAppRepository _repository;
        public AppService(IAppRepository repository) : base(repository)
        {
            _repository = repository;
        }

     

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
        public IPagedList<AppQueryModel> FindPagedListBysql(int paytype, int r_id, int platformid, int auditstate, string sea_name, int type, int SelectState, int appType, string orderby, int pageIndexs, int pageSize)
        {
            var where = new List<string>();
            if (type > 0 && !string.IsNullOrEmpty(sea_name))
            {
                switch (type)
                {
                    case 1:
                        where.Add(string.Format("a.a_id ={0}", sea_name));
                        break;
                    case 2:
                        where.Add(string.Format("a.a_name like '%" + sea_name + "%' "));
                        break;
                    case 3:
                        where.Add(string.Format("b.u_realname like  '%" + sea_name + "%' "));
                        break;
                    case 4:
                        where.Add(string.Format("a.a_key =  '" + sea_name + "'"));
                        break;
                }
            }
            if (paytype > 0)
            {
                where.Add(string.Format("a.a_paymode_id like '%" + paytype + "%' "));
                
            }
            if (auditstate > -1)
            {
                where.Add(string.Format("a.a_auditstate='" + auditstate + "'"));
             
            }
            if (SelectState > -1)
            {
                where.Add(string.Format(" a.a_state='" + SelectState + "' "));
              
            }
            if (platformid > 0)
            {
                where.Add(string.Format("a.a_platform_id=" + platformid + " "));                
            }
            if (r_id > 0)
            {
                where.Add(string.Format("d.r_id=" + r_id + ""));
               
            }
           
            if (appType > 0)
            {
                where.Add(string.Format("typeapp.t_id='" + appType + "'"));
              
            }
            return _repository.FindPagedListBysql(string.Join(" AND ", where), orderby, pageIndexs, pageSize);
        }
        /// <summary>
        /// 审核应用
        /// </summary>
        /// <param name="id">应用ID</param>
        /// <param name="start">状态</param>
        /// <param name="rid">风险等级</param>
        /// <param name="name">审核人员</param>
        /// <returns></returns>
        public bool Updateauditstate(int id, int start, int rid, string name)
        {
            return _repository.Updateauditstate(id,start,rid,name );
        }
        /// <summary>
        /// 一键启用、禁用
        /// </summary>
        /// <param name="start"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateStart(int start, string id)
        {
            return _repository.UpdateStart(start, id);
        }

        public List<ApprateViewModel> SelectAppRateByAppId(int AppId)
        {
            return _repository.SelectAppRateByAppId(AppId);
        }

        public bool AppRateSetup(int id, List<jmp_apprate> appratelist)
        {
            return _repository.AppRateSetup(id, appratelist);
        }
    }
}
