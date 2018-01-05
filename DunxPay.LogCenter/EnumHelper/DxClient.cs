using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.EnumHelper
{
    /// <summary>
    /// 盾行所有平台枚举
    /// </summary>
    public enum   DxClient
    {
        /// <summary>
        /// 运营平台
        /// </summary>
        [Description("运营平台")]
        Administrator=0,
        [Description("开发者平台")]
        Developer=1,
        [Description("商务平台")]
        BusinessPersonnel=2,
        [Description("代理商平台")]
        Agent=3,
        [Description("支付平台")]
         Payment=4,
        [Description("通知平台")]
         Notice =5
    }
}
