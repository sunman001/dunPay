using DunxPay.LogCenter.OperationLog.PlatformLog;

namespace DunxPay.LogCenter.OperationLog.PlatformFactory
{
   public  class AdministratorFactory
    {
        /// <summary>
        /// 管理平台工厂类
        /// </summary>
        /// <returns></returns>
        public static  ILogger CreateLogger(int UserId)
        {
            return new AdministratorLogger(UserId);
        }
    }
}
