using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.Command.Admin.App
{
  public   class AppAuditing
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 风险等级
        /// </summary>
        public int Rid { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        public string Name { get; set; }
    }
}
