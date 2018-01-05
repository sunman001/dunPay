using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter
{
   public   interface ISqlServerLogWriter
   {
       int Insert<T>(T entity);
   }
}
