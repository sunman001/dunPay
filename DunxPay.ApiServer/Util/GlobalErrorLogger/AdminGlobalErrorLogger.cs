using DunxPay.LogCenter.GlobalErrorLog.LoggerFactory;

namespace DunxPay.ApiServer.Util.GlobalErrorLogger
{
    public class AdminGlobalErrorLogger
    {
       /// <summary>
       /// 管理平台错误日志
       /// </summary>
       /// <param name="message">错误信息</param>
       /// <param name="UserId">用户Id</param>
       /// <param name="location"></param>
       /// <param name="summary"></param>
        public static void ErrorLogger(string message, int UserId, string location = "", string summary = "服务器错误")
        {
            var errorLog = new AdministratorErrorLogFactory().CreateErrorLogger(UserId);
            errorLog.Logger(message,location,summary);
        }
    }
}