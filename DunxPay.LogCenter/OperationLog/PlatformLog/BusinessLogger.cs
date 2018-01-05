
using DunxPay.LogCenter.OperationLog.PlatformFactory;
using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.EnumHelper;
using DunxPay.LogCenter.Extensions;


namespace DunxPay.LogCenter.OperationLog.PlatformLog
{
    /// <summary>
    /// 商务平台操作日志实现
    /// </summary>
    public class BusinessLogger : LoggerFactory, ILogger
    {
        private DxBusinessOperationLog dxBusinessOperationLog;
        public BusinessLogger(int UserId)
        {
            dxBusinessOperationLog = new DxBusinessOperationLog();
            dxBusinessOperationLog.CreatedOn = DateTime.Now;
            dxBusinessOperationLog.UserId = UserId ;
            dxBusinessOperationLog.IpAddress= RequestHelper.GetClientIp();          
        }
        public void CreateLog<T>(string summary, T entity)
        {
            dxBusinessOperationLog.Summary = summary;
            dxBusinessOperationLog.LogType = (int)LogType.Create;
            dxBusinessOperationLog.Message = entity.GetCreateEntityPropTracker().Message;
            LogWriter.Log(dxBusinessOperationLog);
        }

        public void LoginLog(string summary, string message)
        {
            dxBusinessOperationLog.Summary = summary;
            dxBusinessOperationLog.LogType = (int)LogType.Login;
            dxBusinessOperationLog.Message = message;
            LogWriter.Log(dxBusinessOperationLog);
        }

        public void ModifyLog<T>(string summary, T original, T modified)
        {
            var message = original.GetModifiedTracker(modified).Message;
            dxBusinessOperationLog.Summary = summary;
            dxBusinessOperationLog.LogType = (int)LogType.Modify;
            dxBusinessOperationLog.Message = message;
            LogWriter.Log(dxBusinessOperationLog);
        }

       public void OperateLog(string summary, string message)
        {
            dxBusinessOperationLog.Summary = summary;
            dxBusinessOperationLog.LogType = (int)LogType.Operate;
            dxBusinessOperationLog.Message = message;
            LogWriter.Log(dxBusinessOperationLog);
        }

        public void VisitLog(string summary, string message)
        {
            dxBusinessOperationLog.Summary = summary;
            dxBusinessOperationLog.LogType = (int)LogType.Visit;
            dxBusinessOperationLog.Message = message;
            LogWriter.Log(dxBusinessOperationLog);
        }
    }
}
