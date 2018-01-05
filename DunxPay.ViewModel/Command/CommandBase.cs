namespace DunxPay.ViewModel.Command
{
    /// <summary>
    /// 列表基本的参数，包括分页参数和排序字段
    /// </summary>
    public class CommandBase
    {
        public CommandBase()
        {
            Rows = 20;
        }
        /// <summary>
        /// 分页大小(每页显示数量,默认:20)
        /// </summary>
        public int Rows { get; set; }

        
        /// <summary>
        /// 当前页数(默认值:1)
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 倒数或者正序
        /// </summary>
        public string Order { get; set; }
    }
}