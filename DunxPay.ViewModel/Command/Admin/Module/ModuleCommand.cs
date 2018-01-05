using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.Command.Admin.Module
{
   public  class ModuleCommand:CommandBase 
    {
        /// <summary>
        /// 查询字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Txtseach { get; set; }
        /// <summary>
        /// 模块状态 1 正常 0  锁定
        /// </summary>
        public int  State { get; set; }
    }
}
