

using DunxPay.LogCenter.EnumHelper;

namespace DunxPay.LogCenter.GlobalErrorLog.LoggerModel
{
    /// <summary>
    /// 商务平台错误日志
    /// </summary>
    public class BusinessPersonnelErrorLogger : AbstractGlobalErrorLogger
    {
        public BusinessPersonnelErrorLogger(int UserId)
        {
            base.DxGlobalLogError.UserId = UserId;
        }
        protected override void SetClient()
        {
            base.DxGlobalLogError.ClientId = (int) DxClient.BusinessPersonnel;
            base.DxGlobalLogError.ClientName = DxClient.BusinessPersonnel.GetDescription();
        }
    }
}
