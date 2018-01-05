using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 平台表
    /// </summary>
    [Alias("jmp_platform")]
    public  class jmp_platform
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int p_id { get; set; }

        public string p_name { get; set; }

        public string p_value { get; set; }
        /// <summary>
        /// 状态 0 禁用 2 启用
        /// </summary>
        public string p_state { get; set; }

    }
}
