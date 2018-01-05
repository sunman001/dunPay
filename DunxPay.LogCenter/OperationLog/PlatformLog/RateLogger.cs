using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.EnumHelper;
using DunxPay.LogCenter.Extensions;
using DunxPay.LogCenter.OperationLog.PlatformFactory;


namespace DunxPay.LogCenter.OperationLog.PlatformLog
{
    /// <summary>
    ///费率相关操作日志实现
    /// </summary>
    public class RateLogger : LoggerFactory, ILogger
    {
        private DxRateOperationLog dxRateOperationLog;
        public RateLogger(int UserId)
        {
            dxRateOperationLog = new DxRateOperationLog();
            dxRateOperationLog.IpAddress = RequestHelper.GetClientIp();
            dxRateOperationLog.UserId = UserId;
            dxRateOperationLog.CreatedOn = DateTime.Now;
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="summary"></param>
        /// <param name="entity"></param>
        public void CreateLog<T>(string summary, T entity)
        {
            dxRateOperationLog.LogType = (int)LogType.Create;
            dxRateOperationLog.Summary = summary;
            dxRateOperationLog.Message = entity.GetCreateEntityPropTracker().Message;
            LogWriter.Log(dxRateOperationLog);
        }
        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="message"></param>
        public void LoginLog(string summary, string message)
        {
            dxRateOperationLog.LogType = (int)LogType.Login;
            dxRateOperationLog.Summary = summary;
            dxRateOperationLog.Message = message;
            LogWriter.Log(dxRateOperationLog);
        }
        /// <summary>
        /// 修改日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="summary"></param>
        /// <param name="original"></param>
        /// <param name="modified"></param>
        public void ModifyLog<T>(string summary, T original, T modified)
        {
            var message = original.GetModifiedTracker(modified).Message;
            dxRateOperationLog.LogType = (int)LogType.Modify;
            dxRateOperationLog.Summary = summary;
            dxRateOperationLog.Message = message;
            LogWriter.Log(dxRateOperationLog);
         
        }
        /// <summary>
        /// 操作日志如锁定、解冻、导入导出等
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="message"></param>
        public void OperateLog(string summary, string message)
        {
            dxRateOperationLog.LogType = (int)LogType.Operate;
            dxRateOperationLog.Summary = summary;
            dxRateOperationLog.Message = message;
            LogWriter.Log(dxRateOperationLog);
        }
        /// <summary>
        /// 访问日志
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="message"></param>
        public void VisitLog(string summary, string message)
        {
            dxRateOperationLog.LogType = (int)LogType.Visit;
            dxRateOperationLog.Summary = summary;
            dxRateOperationLog.Message = message;
            LogWriter.Log(dxRateOperationLog);
        }

       
    }
}
