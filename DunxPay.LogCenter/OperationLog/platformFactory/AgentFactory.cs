using DunxPay.LogCenter.OperationLog.PlatformLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.OperationLog.PlatformFactory
{
    public class AgentFactory
    {
        /// <summary>
        /// 代理商平台工厂类
        /// </summary>
        /// <returns></returns>
        public static ILogger  CeateLogger(int UserId)
            {
            return new  AgentLogger(UserId);
            }
    }
}
