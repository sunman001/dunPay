using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.EnumHelper;
using DunxPay.LogCenter.Extensions;


namespace DunxPay.LogCenter.GlobalErrorLog.LoggerModel
{
    /// <summary>
    /// 通知平台错误日志实现类
    /// </summary>
    public class NoticeErrorLogger : ErrorLoggerManger, IErrorLogger
    {
        protected DxNotificationLog DxNotificationLog;
        public NoticeErrorLogger(int UserId)
        {
            DxNotificationLog = new DxNotificationLog
            {
                CreatedOn = DateTime.Now,
                UserId = UserId,
                IpAddress = RequestHelper.GetClientIp(),
                TypeValue = 1
            };
            throw new Exception();
        }
        public void Logger(string message, string location = "", string summary = "")
        {
            DxNotificationLog.Message = message;
            DxNotificationLog.Location = location;
            DxNotificationLog.Summary = summary;
            DxNotificationLog.ClientId = (int)DxClient.Notice;
            DxNotificationLog.ClientName = DxClient.Notice.GetDescription();
            errorLoggerWriter.Writer(DxNotificationLog);
        }
    }
}
