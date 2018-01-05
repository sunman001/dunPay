
using DunxPay.LogCenter.EnumHelper;

namespace DunxPay.LogCenter.GlobalErrorLog.LoggerModel
{
    /// <summary>
    /// 管理平台实现类
    /// </summary>
    public class AdministratorErrorLogger : AbstractGlobalErrorLogger
    {
        public AdministratorErrorLogger(int UserId)
        {
            base.DxGlobalLogError.UserId = UserId;
        }
        protected override void SetClient()
        {
            base.DxGlobalLogError.ClientId = (int)DxClient.Administrator;
            base.DxGlobalLogError.ClientName = DxClient.Administrator.GetDescription();
        }
    }
}
