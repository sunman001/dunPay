using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Configuration;

namespace DunxPay.LogCenter
{
   public  class DbConnectionFactory
    {
        protected static string ConnectionString { get; set; }

        static DbConnectionFactory()
        {
            OrmLiteConfig.DialectProvider = SqlServer2014Dialect.Provider;
            ConnectionString = ConfigurationManager.AppSettings["ConnectionStringLog"];
        }
        public static IDbConnection GetDbConnection(string connString = null)
        {
            connString = connString ?? ConnectionString;
            return connString.OpenDbConnection();
        }
    }
}
