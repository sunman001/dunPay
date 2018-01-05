using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.GlobalErrorLog
{
  public   interface IErrorLoggerWriter
    {
        /// <summary>
        /// 写入数据库的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="errorLogger"></param>
        void Writer<T>(T errorLogger);
    }
}
