using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter
{
   public  class SqlServerLogWriterManger
    {
        public static ISqlServerLogWriter GetSqlServerLogWriter()
        {
            return new SqlServerLogWriter();
        }
    }
}
