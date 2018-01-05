using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.Command.Admin.App
{
    public class AppTypeCommand : CommandBase
    {
        /// <summary>
        /// 所属应用类型ID
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 查询字段
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string   State { get; set; }
    }
}
