
using DunxPay.LogCenter.OperationLog.PlatformFactory;
using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.EnumHelper;
using DunxPay.LogCenter.Extensions;


namespace DunxPay.LogCenter.OperationLog.PlatformLog
{
    /// <summary>
    /// 开发者平台操作日志实现
    /// </summary>
    public class DevelopLogger : LoggerFactory, ILogger
    {
        private DxDevelopOperationLog dxDevelopOperationLog;
        public DevelopLogger(int UserId)
        {
            dxDevelopOperationLog = new DxDevelopOperationLog();
            dxDevelopOperationLog.CreatedOn = DateTime.Now;
            dxDevelopOperationLog.UserId = UserId ;
            dxDevelopOperationLog.IpAddress= RequestHelper.GetClientIp();
           
        }
        public void CreateLog<T>(string summary, T entity)
        {
            dxDevelopOperationLog.Summary = summary;
            dxDevelopOperationLog.LogType = (int)LogType.Create;
            dxDevelopOperationLog.Message = entity.GetCreateEntityPropTracker().Message;
            LogWriter.Log(dxDevelopOperationLog);
        }

        public void LoginLog(string summary, string message)
        {
            dxDevelopOperationLog.Summary = summary;
            dxDevelopOperationLog.LogType = (int)LogType.Login;
            dxDevelopOperationLog.Message = message;
            LogWriter.Log(dxDevelopOperationLog);
        }

        public void ModifyLog<T>(string summary, T original, T modified)
        {
            var message = original.GetModifiedTracker(modified).Message;
            dxDevelopOperationLog.Summary = summary;
            dxDevelopOperationLog.LogType = (int)LogType.Modify;
            dxDevelopOperationLog.Message = message;
            LogWriter.Log(dxDevelopOperationLog);
        }

        public void OperateLog(string summary, string message)
        {
            dxDevelopOperationLog.Summary = summary;
            dxDevelopOperationLog.LogType = (int)LogType.Operate;
            dxDevelopOperationLog.Message = message;
            LogWriter.Log(dxDevelopOperationLog);
        }

        public void VisitLog(string summary, string message)
        {
            dxDevelopOperationLog.Summary = summary;
            dxDevelopOperationLog.LogType = (int)LogType.Visit;
            dxDevelopOperationLog.Message = message;
            LogWriter.Log(dxDevelopOperationLog);
        }
    }
}
