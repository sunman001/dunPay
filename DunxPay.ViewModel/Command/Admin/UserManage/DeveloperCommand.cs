namespace DunxPay.ViewModel.Command.Admin.UserManage
{
    public class DeveloperCommand : CommandBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 查询类型
        /// </summary>
        public int SearchType { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 冻结启用状态
        /// </summary>
        public string SearchState { get; set; }

        /// <summary>
        /// ID字符串（用户批量操作）
        /// </summary>
        public string IdList { get; set; }

        /// <summary>
        /// 认证类型
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 上级类型
        /// </summary>
        public string Relation_type { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public string Auditstate { get; set; }

        /// <summary>
        /// 风控资料
        /// </summary>
        public string RiskM { get; set; }

    }
}
