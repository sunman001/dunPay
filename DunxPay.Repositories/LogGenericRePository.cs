using Infrastructure;

namespace DunxPay.Repositories
{
    /// <summary>
    /// 日志泛型服务类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LogGenericRePository<T> : GenericRepository<T> where T : class, new()
    {
        /// <summary>
        /// 获取日志的数据库连接工厂
        /// </summary>
        protected override AbstractDbConnectionFactory DbFactory { get { return new LogDbConnectionFactory(); } }
    }
}
