using System;


namespace DunxPay.LogCenter.OperationLog
{
    /// <summary>
    /// 实现日志写入数据库的类
    /// </summary>
    public class LogWriter : ILogWriter
    {
       
        public void Log<T>(T operationLog)
        {
            ISqlServerLogWriter logWriter = SqlServerLogWriterManger.GetSqlServerLogWriter();
            var obInsert= logWriter.Insert(operationLog);
            if (obInsert <= 0)
            {
                throw new Exception("添加日志失败！");
            }
        }
    }
}
