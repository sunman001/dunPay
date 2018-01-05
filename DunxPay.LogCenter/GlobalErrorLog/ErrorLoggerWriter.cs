using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.GlobalErrorLog
{
    public class ErrorLoggerWriter : IErrorLoggerWriter
    {
        /// <summary>
        /// 实现添加数据库方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="errorLogger"></param>
        public void Writer<T>(T errorLogger)
        {
            ISqlServerLogWriter logWriter = SqlServerLogWriterManger.GetSqlServerLogWriter();
            var obInsert = logWriter.Insert(errorLogger);
            if (obInsert <= 0)
            {
                throw new Exception("添加日志失败！");
            }
        }
    }
}
