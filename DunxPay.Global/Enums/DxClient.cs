using System.ComponentModel;

namespace DunxPay.Global.Enums
{
    /// <summary>
    /// 平台枚举
    /// </summary>
    public enum DxClient
    {
        /// <summary>
        /// 运营平台
        /// </summary>
        [Description("运营平台")]
        Administrator = 1,
        /// <summary>
        /// 开发者平台
        /// </summary>
        [Description("开发者平台")]
        Developer = 2,
        /// <summary>
        /// 商务平台
        /// </summary>
        [Description("商务平台")]
        BusinessPersonnel = 3,

        /// <summary>
        /// 代理商平台
        /// </summary>
        [Description("代理商平台")]
        Agent = 4,


    }
}
