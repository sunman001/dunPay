
using DunxPay.LogCenter.OperationLog.PlatformFactory;
using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.EnumHelper;
using DunxPay.LogCenter.Extensions;


namespace DunxPay.LogCenter.OperationLog.PlatformLog
{
    /// <summary>
    /// 代理商平台操作日志实现
    /// </summary>
    public class AgentLogger : LoggerFactory, ILogger
    {
        private DxAgentOperationLog dXAgentOperationLog;
        public AgentLogger (int UserId)
        {
            dXAgentOperationLog = new DxAgentOperationLog();
            dXAgentOperationLog.IpAddress = RequestHelper.GetClientIp();
            dXAgentOperationLog.CreatedOn = DateTime.Now;
            dXAgentOperationLog.UserId = UserId;
        }
        public void CreateLog<T>(string summary, T entity)
        {
            dXAgentOperationLog.Summary = summary;
            dXAgentOperationLog.LogType = (int)LogType.Create;
            dXAgentOperationLog.Message= entity.GetCreateEntityPropTracker().Message;
            LogWriter.Log(dXAgentOperationLog);
        }

        public void LoginLog(string summary, string message)
        {
            dXAgentOperationLog.Summary = summary;
            dXAgentOperationLog.LogType = (int)LogType.Login;
            dXAgentOperationLog.Message = message;
            LogWriter.Log(dXAgentOperationLog);
        }

        public void ModifyLog<T>(string summary, T original, T modified)
        {
            var message= original.GetModifiedTracker(modified).Message;
            dXAgentOperationLog.Summary = summary;
            dXAgentOperationLog.LogType = (int)LogType.Modify;
            dXAgentOperationLog.Message = message;
            LogWriter.Log(dXAgentOperationLog);
        }

        public void OperateLog(string summary, string message)
        {
            dXAgentOperationLog.Summary = summary;
            dXAgentOperationLog.LogType = (int)LogType.Operate;
            dXAgentOperationLog.Message = message;
            LogWriter.Log(dXAgentOperationLog);
        }

        public void VisitLog(string summary, string message)
        {
            dXAgentOperationLog.Summary = summary;
            dXAgentOperationLog.LogType = (int)LogType.Visit;
            dXAgentOperationLog.Message = message;
            LogWriter.Log(dXAgentOperationLog);
        }
    }
}
