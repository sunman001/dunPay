namespace DunxPay.Domain.QueryModel.Admin.User
{

    /// <summary>
    /// 用户可用权限领域实体类
    /// </summary>
    public class PermissionQueryModel
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        public string ModuleCode { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 操作码
        /// </summary>
        public string ActionCode { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int ClientId { get; set; }
        /// <summary>
        /// 是否是按钮
        /// </summary>
        public bool IsButton { get; set; }
        /// <summary>
        /// 按钮类型
        /// </summary>
        public int ButtonType { get; set; }
        /// <summary>
        /// 操作函数
        /// </summary>
        public string JsOperatingFunction { get; set; }
        /// <summary>
        /// 按钮图标
        /// </summary>
        public string ButtonIcon { get; set; }
    }
}
