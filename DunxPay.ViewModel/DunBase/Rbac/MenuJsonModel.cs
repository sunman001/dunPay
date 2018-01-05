using System.Collections.Generic;

namespace DunxPay.ViewModel.DunBase.Rbac
{
    /// <summary>
    /// 菜单的查询实体类
    /// </summary>
    public class MenuJsonModel
    {
        public MenuJsonModel()
        {
            //State = "closed";
            Children =new List<MenuJsonModel>();
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标识码
        /// </summary>
        public string IdentifyCode { get; set; }
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
        public string IconCls { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 子菜单数量
        /// </summary>
        public int ChildCount { get; set; }
        /// <summary>
        /// 菜单层级深度
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 树形文本文字
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 状态子节点是否关闭
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 模块编码[平台内的编码不能重复]
        /// </summary>
        public string Code { get; set; }
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
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuJsonModel> Children { get; set; }
    }
}
