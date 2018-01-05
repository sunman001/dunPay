using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.GlobalErrorLog
{
    /// <summary>
    /// 实例化写入类实列
    /// </summary>
    public abstract class ErrorLoggerManger
    {
        protected IErrorLoggerWriter errorLoggerWriter;

        protected ErrorLoggerManger()
        {
            errorLoggerWriter = new ErrorLoggerWriter();
        }
    }
}
