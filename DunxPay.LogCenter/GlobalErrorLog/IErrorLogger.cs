using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.GlobalErrorLog
{
    /// <summary>
    /// 对客户端的写日志对接
    /// </summary>
   public  interface IErrorLogger
    {
        /// <summary>
        /// 写入错误日志接口
        /// </summary>
        /// <param name="message"></param>
        /// <param name="location"></param>
        /// <param name="summary"></param>
        void Logger(string message,string location="",string summary="");                                                                                                           

    }
}
