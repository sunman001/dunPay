namespace DunxPay.LogCenter.OperationLog.PlatformFactory
{
    public abstract class LoggerFactory
    {
        protected ILogWriter LogWriter;
        public LoggerFactory()
        {
            LogWriter = new LogWriter();
        }
    }
}
