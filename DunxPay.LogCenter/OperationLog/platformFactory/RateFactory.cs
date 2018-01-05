using DunxPay.LogCenter.OperationLog.PlatformLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.OperationLog.PlatformFactory
{
   public  class RateFactory
    {
        /// <summary>
        /// 费率相关操作日志工厂类
        /// </summary>
        /// <returns></returns>
        public static ILogger CreateLogger(int UserId)
        {
            return new RateLogger(UserId);
        }
    }
}
