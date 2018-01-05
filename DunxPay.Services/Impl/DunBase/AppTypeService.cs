/**********************************************
文件名：DxModuleActionService.cs
作者：dunxingpay.com
日期：2017/11/30
描述：[模块-操作信息表]服务实现
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Global;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Services.Impl.DunBase
{
    public class AppTypeService : GenericService<jmp_apptype>, IAppTypeService
    {
        private readonly IAppTypeRepository _repository;
        public AppTypeService(IAppTypeRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<jmp_apptype> FindListByPay()
        {
            return _repository.FindListByPay();
        }

        public IPagedList<AppTypeViewModel> FindPagedListBysql(int pid, string keyword, string type, int state, string orderby, int pageIndexs, int pageSize)
        {
            var where = new List<string>();
            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(keyword))
            {
                switch (type)
                {
                    case "1":
                     where.Add(string.Format("a.t_id={0}", keyword));
                        break;
                    case "2":
                        where.Add(string.Format("a.t_name like '%" + keyword + "%'"));                      
                        break;
                }
            }
            if (state > -1)
            {
                where.Add(string.Format("a.t_state={0}", state));
             
            }
            if (pid > -1)
            {
                where.Add(string.Format("a.t_topid={0}", pid));
                
            }
            return _repository.FindPagedListBysql(string.Join(" AND ", where), orderby, pageIndexs, pageSize);
        }

        public bool UpdateStart(int start, string id)
        {
            return _repository.UpdateStart(start, id);
        }
    }
}