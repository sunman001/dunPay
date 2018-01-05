using System;
using ServiceStack.DataAnnotations;

namespace DunxPay.LogCenter.DxLogDomain
{
    /// <summary>
    /// 商务平台操作日志
    /// </summary>
    [Alias("DxBusinessOperationLog")]
    public  class DxBusinessOperationLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public int LogType { get; set; }
        /// <summary>
        /// Ip地址
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 摘要信息
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 详细信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 创建ID
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
