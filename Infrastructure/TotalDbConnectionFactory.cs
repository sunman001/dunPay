using System;
using System.Configuration;
using ServiceStack.OrmLite;


namespace Infrastructure
{
  public   class TotalDbConnectionFactory : AbstractDbConnectionFactory
    {
        static TotalDbConnectionFactory()
        {
            OrmLiteConfig.DialectProvider = SqlServer2014Dialect.Provider;
        }

        protected override string ConnectionStringName
        {
            get { return "ConnectionStringTotal"; }
        }

       
    }
}
