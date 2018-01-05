using Infrastructure;

namespace DunxPay.Repositories
{
    /// <summary>
    /// 基于dx_base数据库的操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseGenericRepository<T> : GenericRepository<T> where T : class, new()
    {
        /// <summary>
        /// 基础数据连接工厂
        /// </summary>
        protected override AbstractDbConnectionFactory DbFactory { get { return new BaseDbConnectionFactory(); } }
    }
}
