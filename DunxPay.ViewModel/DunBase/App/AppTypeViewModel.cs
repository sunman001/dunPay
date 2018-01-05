using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.App
{
   public  class AppTypeViewModel
    {
        /// <summary>
        /// 应用类型ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 应用类型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 所属类型
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 所属类型名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
    }
}
