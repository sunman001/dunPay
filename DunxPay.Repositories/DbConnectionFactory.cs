using ServiceStack.OrmLite;
using System.Configuration;
using System.Data;

namespace DunxPay.Repositories
{
    /// <summary>
    /// 数据库连接工厂类
    /// </summary>
    public class DbConnectionFactory
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected static string ConnectionString { get; set; }

        static DbConnectionFactory()
        {
            OrmLiteConfig.DialectProvider = SqlServer2014Dialect.Provider;
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        /// <summary>
        /// 获取IDbConnection对象
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection(string connString = null)
        {
            connString = connString ?? ConnectionString;
            return connString.OpenDbConnection();
        }
    }
}
