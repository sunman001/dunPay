
using DunxPay.LogCenter.GlobalErrorLog.LoggerModel;

namespace DunxPay.LogCenter.GlobalErrorLog.LoggerFactory
{
   public  class DevelopErrorLogFactory:IAbstractErrorLogFactory
    {
        public IErrorLogger CreateErrorLogger(int UserId)
        {
           return new DevelopErrorLogger(UserId );
        }
    }
}
