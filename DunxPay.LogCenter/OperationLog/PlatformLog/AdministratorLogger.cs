
using DunxPay.LogCenter.OperationLog.PlatformFactory;
using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.EnumHelper;
using DunxPay.LogCenter.Extensions;


namespace DunxPay.LogCenter.OperationLog.PlatformLog
{
    /// <summary>
    /// 管理平台操作日志实现
    /// </summary> 
    public class AdministratorLogger : LoggerFactory, ILogger
    {
        private DxAdminOperationLog dxAdminOperationLog;
        public AdministratorLogger(int UserId)
        {
            dxAdminOperationLog = new DxAdminOperationLog
            {
                IpAddress = RequestHelper.GetClientIp(),
                UserId = UserId,
                CreatedOn = DateTime.Now
            };

        }
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="summary"></param>
        /// <param name="entity"></param>
        public void CreateLog<T>(string summary, T entity)
        {
            dxAdminOperationLog.LogType = (int)LogType.Create;
            dxAdminOperationLog.Summary = summary;
            dxAdminOperationLog.Message = entity.GetCreateEntityPropTracker().Message;
            LogWriter.Log(dxAdminOperationLog);
        }
        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="message"></param>
        public void LoginLog(string summary, string message)
        {
            dxAdminOperationLog.LogType = (int)LogType.Login;
            dxAdminOperationLog.Summary = summary;
            dxAdminOperationLog.Message = message;
            LogWriter.Log(dxAdminOperationLog);
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
            dxAdminOperationLog.LogType = (int)LogType.Modify;
            dxAdminOperationLog.Summary = summary;
            dxAdminOperationLog.Message = message;
            LogWriter.Log(dxAdminOperationLog);
         
        }
        /// <summary>
        /// 操作日志如锁定、解冻、导入导出等
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="message"></param>
        public void OperateLog(string summary, string message)
        {
            dxAdminOperationLog.LogType = (int)LogType.Operate;
            dxAdminOperationLog.Summary = summary;
            dxAdminOperationLog.Message = message;
            LogWriter.Log(dxAdminOperationLog);
        }
        /// <summary>
        /// 访问日志
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="message"></param>
        public void VisitLog(string summary, string message)
        {
            dxAdminOperationLog.LogType = (int)LogType.Visit;
            dxAdminOperationLog.Summary = summary;
            dxAdminOperationLog.Message = message;
            LogWriter.Log(dxAdminOperationLog);
        }

       
    }
}
