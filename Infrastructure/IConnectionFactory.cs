using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public  interface IConnectionFactory
   {
       IDbConnection GetConnection { get; }
   }
}
