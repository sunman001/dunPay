
namespace DunxPay.LogCenter.OperationLog
{
    /// <summary>
    /// 日志接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public  interface ILogWriter
    {
       /// <summary>
       /// 写日志的方法
       /// </summary>
       /// <typeparam name="T">泛型</typeparam>
       /// <param name="logtype">日志类型</param>
       /// <param name="summary">摘要</param>
       /// <param name="message">详细信息</param>
        void Log<T>(T OperationLog);
    }
}
