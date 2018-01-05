using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.App
{
   public  class RisklevelallocationViewModel
    {
        public int RId { get; set; }
        /// <summary>
        /// 应用类型父级id
        /// </summary>
       
        public int RApptypeid { get; set; }
        /// <summary>
        /// 关联风险等级表id
        /// </summary>
     
        public int RRisklevel { get; set; }

        /// <summary>
        /// 状态（0：正常，1冻结）
        /// </summary>
        public int RState { get; set; }

        /// <summary>
        /// 等级名称
        /// </summary>
        public string RName { get; set; }
    }
}
