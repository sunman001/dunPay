using DunxPay.LogCenter.GlobalErrorLog.LoggerModel;


namespace DunxPay.LogCenter.GlobalErrorLog.LoggerFactory
{
    public class AdministratorErrorLogFactory : IAbstractErrorLogFactory
    {
        public IErrorLogger CreateErrorLogger(int UserId)
        {
            return new AdministratorErrorLogger(UserId);
        }

       
    }
}
