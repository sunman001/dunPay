using System;
using ServiceStack.DataAnnotations;

namespace DunxPay.LogCenter.DxLogDomain
{
    /// <summary>
    /// 接口全局错误记录表
    /// </summary>
    [Alias("DxPayLogError")]
    public  class DxPayLogError
    {
        /// <summary>
        /// ID
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
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 错误类型 1、错误 2、警告
        /// </summary>
        public int TypeValue { get; set; }

        /// <summary>
        /// Ip 地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 出错位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 摘要信息
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 日志详细信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
