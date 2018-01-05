using DunxPay.ApiServer.Util.UserManager;
using DunxPay.LogCenter.OperationLog;
using DunxPay.LogCenter.OperationLog.PlatformFactory;

namespace DunxPay.ApiServer.Util.LogWriter
{
    public class AdminLogFactory : IAdminLogFactory
    {
        public ILogger Logger
        {
            get { return AdministratorFactory.CreateLogger(UserContext.Id); }
        }
    }
}