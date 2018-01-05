namespace DunxPay.ViewModel.Command.Admin
{
    public class LogSearchCommand:CommandBase
    {
        /// <summary>
        /// 查询字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Txtseach { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public int Logtype { get; set; }
    }
}