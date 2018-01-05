/**********************************************
文件名：DxModuleActionRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[模块-操作信息表]仓储层实现
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Repositories.Inter.DunBase;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
	public class DxModuleActionRepository: BaseGenericRepository<DxModuleAction>,IDxModuleActionRepository
	{
	    /// <summary>
	    /// 根据用户ID修改用户状态
	    /// </summary>
	    /// <param name="start">禁用启用状态</param>
	    /// <param name="id">用户ID</param>
	    /// <returns></returns>
	    public bool UpdateStart(int start, string id)
	    {
	        using (var db = DbFactory.GetConnection)
	        {
	            var sql = @"update DxModuleAction set IsEnabled=@start where id in(" + id + ") ";

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