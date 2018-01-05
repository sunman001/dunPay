using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DunxPay.Domain.DunBase;
using DunxPay.Global;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Repositories.Inter.DunBase
{
  public   interface IAppTypeRepository:IRepository<jmp_apptype>
  {

        /// <summary>
        /// 分页查询应用类型
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndexs">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
      IPagedList<AppTypeViewModel> FindPagedListBysql(string @where, string orderby,int pageIndexs, int pageSize);
      bool UpdateStart(int start, string id);
      /// <summary>
      /// 查询正在用的应用类型
      /// </summary>
      /// <returns></returns>
      List<jmp_apptype> FindListByPay();
    }
}
