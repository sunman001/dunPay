

using DunxPay.LogCenter.EnumHelper;

namespace DunxPay.LogCenter.GlobalErrorLog.LoggerModel
{
    /// <summary>
    /// 代理商全局错误日志
    /// </summary>
    public class AgentErrorLogger : AbstractGlobalErrorLogger
    {
        public AgentErrorLogger(int UserId)
        {
            base.DxGlobalLogError.UserId = UserId;
        }

        protected override void SetClient()
        {
            base.DxGlobalLogError.ClientId = (int) DxClient.Agent;
            base.DxGlobalLogError.ClientName = DxClient.Agent.GetDescription();
        }
    }
}
