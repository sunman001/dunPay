using System;
using ServiceStack.DataAnnotations;

namespace DunxPay.LogCenter.DxLogDomain
{
    /// <summary>
    /// 通知日志记录表
    /// </summary>
    [Alias("DxNotificationLog")]
    public   class DxNotificationLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int ClientId { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string ClientName { get; set; }
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
        public string Location { get; set; }

        /// <summary>
        /// 1错误 2、警告
        /// </summary>
        public int TypeValue { get; set; }

    }
}
