using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 应用类型表
    /// </summary>
    [Alias("jmp_apptype")]
  public   class jmp_apptype
    {

        /// <summary>
        /// 自增ID
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int t_id { get; set; }

        public string t_name { get; set; }

        public string t_sort { get; set; }
        public int t_topid { get; set; }

        public int t_state { get; set; }
    }
}
