using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 支付类型表
    /// </summary>
    [Alias("jmp_paymode")]
    public  class jmp_paymode
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int  p_id { get; set; }

        public string p_name { get; set; }

        public decimal p_rate { get; set; }

        /// <summary>
        /// 状态 1正常 0 冻结
        /// </summary>
        public int p_state { get; set; }

        public string p_islocked { get; set; }
    }
}
