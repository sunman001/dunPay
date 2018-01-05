using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.GlobalErrorLog.LoggerFactory
{
    public interface IAbstractErrorLogFactory
    {
        IErrorLogger CreateErrorLogger(int UserId);
    }
}
