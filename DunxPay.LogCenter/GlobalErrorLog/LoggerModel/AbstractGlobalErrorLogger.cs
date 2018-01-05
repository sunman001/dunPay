
using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.Extensions;


namespace DunxPay.LogCenter.GlobalErrorLog.LoggerModel
{
    /// <summary>
    /// 抽象出各平台同表同步的部分
    /// </summary>
    public abstract class AbstractGlobalErrorLogger : ErrorLoggerManger, IErrorLogger
    {
        protected DxGlobalLogError DxGlobalLogError;
        protected AbstractGlobalErrorLogger()
        {
            DxGlobalLogError = new DxGlobalLogError
            {
                TypeValue = 1
            };
            Init();
        }
        protected void Init()
        {
            SetClient();
        }
        protected abstract void SetClient();
        public void Logger(string message, string location = "", string summary = "")
        {
            DxGlobalLogError.IpAddress = RequestHelper.GetClientIp();
            DxGlobalLogError.Message = message;
            DxGlobalLogError.Location = location;
            DxGlobalLogError.Summary = summary;
            DxGlobalLogError.CreatedOn = DateTime.Now;
            errorLoggerWriter.Writer(DxGlobalLogError);
           // throw new Exception();
        }
    }
}
