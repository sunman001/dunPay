using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;

namespace DunxPay.LogCenter
{
    public class SqlServerLogWriter : ISqlServerLogWriter
    {
    private IDbConnection Db = DbConnectionFactory.GetDbConnection();

    public  int Insert <T>(T entity)
    {
        using (Db)
        {
            return (int) Db.Insert(entity, true);
        }
    }
    }
}
