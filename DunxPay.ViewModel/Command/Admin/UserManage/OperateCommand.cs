namespace DunxPay.ViewModel.Command.Admin.UserManage
{
    public class OperateCommand : CommandBase
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
        public int SearchState { get; set; }

        /// <summary>
        /// ID字符串（用户批量操作）
        /// </summary>
        public string IdList { get; set; }


    }
}
