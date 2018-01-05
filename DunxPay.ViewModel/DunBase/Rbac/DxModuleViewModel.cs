using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.Rbac
{
   public  class DxModuleViewModel
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标识码
        /// </summary>
        public string IdentifyCode { get; set; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public int  ParentId { get; set; }
        /// <summary>
        /// 父级标识码
        /// </summary>
        public string ParentIdentifyCode { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
       
        
        /// <summary>
        /// 排序[从小到大]
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 子节点数
        /// </summary>
        public int? ChildCount { get; set; }
        /// <summary>
        /// 菜单级数
        /// </summary>
        public int? ChildLevel { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
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
        public string CreatedByUserName { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// ModifiedByUserName
        /// </summary>
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int? ClientId { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 是否可用[0:否,1:是],默认值:1
        /// </summary>
        public bool? IsEnabled { get; set; }
        /// <summary>
        /// 是否已被删除[0:否,1:是],默认值:0
        /// </summary>
        public bool? IsDeleted { get; set; }


    }
}
