

using DunxPay.LogCenter.EnumHelper;

namespace DunxPay.LogCenter.GlobalErrorLog.LoggerModel
{
    /// <summary>
    /// 开发者平台实现类
    /// </summary>
    public class DevelopErrorLogger : AbstractGlobalErrorLogger
    {
        public DevelopErrorLogger(int UserId)
        {
            base.DxGlobalLogError.UserId = UserId;
        }

        protected override void SetClient()
        {
            base.DxGlobalLogError.ClientId = (int)DxClient.Developer;
            base.DxGlobalLogError.ClientName = DxClient.Developer.GetDescription();
        }
    }
}
