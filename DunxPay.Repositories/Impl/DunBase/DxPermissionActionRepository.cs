/**********************************************
文件名：DxPermissionActionRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[权限-操作关系映射表]仓储层实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Repositories.Inter.DunBase;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class DxPermissionActionRepository : BaseGenericRepository<DxPermissionAction>, IDxPermissionActionRepository
    {
        public bool BatchInsert(List<DxPermissionAction> list)
        {
            using (var db = DbFactory.GetConnection)
            {
                var a = db.SaveAll(list);
                if (a > 0)
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