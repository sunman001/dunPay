using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.Rbac
{
   public  class DxModuleActionViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 模块惟一标识码[关联DxModule表]
        /// </summary>
        public string ModuleIdentifyCode { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 操作码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool? IsEnabled { get; set; }
        /// <summary>
        /// 排序[从小到大]
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? CreatedByUserId { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 是否是按钮
        /// </summary>
        public string  IsButton { get; set; }

        /// <summary>
        /// 按钮类型
        /// </summary>
        public int? ButtonType { get; set; }

        /// <summary>
        /// js操作函数
        /// </summary>
        public string JsOperatingFunction { get; set; }

        /// <summary>
        /// 按钮图标
        /// </summary>
        public string ButtonIcon { get; set; }
    }
}
