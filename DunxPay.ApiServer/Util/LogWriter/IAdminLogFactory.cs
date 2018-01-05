using DunxPay.LogCenter.OperationLog;

namespace DunxPay.ApiServer.Util.LogWriter
{
    public interface IAdminLogFactory
    {
        ILogger Logger { get; }
    }
}
