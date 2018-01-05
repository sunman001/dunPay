namespace DunxPay.ViewModel.DunBase.Rbac
{
    /// <summary>
    /// 菜单的查询实体类
    /// </summary>
    public class MenuViewModel
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
        public string ParentId { get; set; }
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
    }
}
