using ServiceStack.OrmLite;
using System;
using System.Configuration;
using System.Data;


namespace Infrastructure
{
    /// <summary>
    /// 数据库连接工厂抽象基类
    /// </summary>
    public abstract class AbstractDbConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        protected abstract string ConnectionStringName { get; }

        protected AbstractDbConnectionFactory()
        {
            OrmLiteConfig.DialectProvider = SqlServer2014Dialect.Provider;
        }

        /// <summary>
        /// 获取并打开一个数据库连接
        /// </summary>
        public IDbConnection GetConnection
        {
            get
            {
                if (string.IsNullOrEmpty(ConnectionStringName))
                {
                    throw new ArgumentNullException("Connection string is empty.");
                }
                return ConfigurationManager.AppSettings[ConnectionStringName].OpenDbConnection();
            }
        }
    }
}
