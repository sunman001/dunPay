/**********************************************
文件名：DxPermissionRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块-角色关系映射表]仓储层实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Repositories.Inter.DunBase;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class DxPermissionRepository : BaseGenericRepository<DxPermission>, IDxPermissionRepository
    {
        public bool BatchInsert(List<DxPermission> list)
        {
            using (var db = DbFactory.GetConnection)
            {
               var a=  db.SaveAll(list);
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