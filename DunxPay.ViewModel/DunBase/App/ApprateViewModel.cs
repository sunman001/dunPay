using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.App
{
  public   class ApprateViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int r_id { get; set; }
        /// <summary>
        /// 应用id
        /// </summary>
        public int r_appid { get; set; }
        /// <summary>
        /// 支付类型id
        /// </summary>
        public int r_paymodeid { get; set; }
        /// <summary>
        /// 手续费比例
        /// </summary>
        public decimal r_proportion { get; set; }
        /// <summary>
        /// 状态（0：正常，1冻结）
        /// </summary>
        public int r_state { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime r_time { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public string r_name { get; set; }
   
        /// <summary>
        /// 支付类型名称
        /// </summary>
        public string p_name { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
   
        public string u_realname { get; set; }
        /// <summary>
        /// 用户登陆名
        /// </summary>
     
        public string u_email { get; set; }
        /// <summary>
        /// 支付类型id
        /// </summary>
     
        public int p_id { get; set; }
       
    }
}
