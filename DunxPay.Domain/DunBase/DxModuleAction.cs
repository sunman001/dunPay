/**********************************************
文件名：DxModuleAction.cs
作者：dunxingpay.com
日期：2017/11/30
描述：数据表[模块-操作信息表]实体类
**********************************************/
using ServiceStack.DataAnnotations;
using System;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 数据表[模块-操作信息表]实体类
    /// </summary>
    [Alias("DxModuleAction")]
    public class DxModuleAction
    {
        /// <summary>
        /// Id
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        /// <summary>
        /// 模块惟一标识码[关联DxModule表]
        /// </summary>
    	public string ModuleIdentifyCode { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
    	public string Name { get; set; }
        /// <summary>
        /// 操作码
        /// </summary>
    	public string Code { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
    	public bool? IsEnabled { get; set; }
        /// <summary>
        /// 排序[从小到大]
        /// </summary>
    	public int? Sort { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
    	public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
    	public int? CreatedByUserId { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
    	public string CreatedBy { get; set; }

        /// <summary>
        /// 是否是按钮
        /// </summary>
        public bool? IsButton { get; set; }

        /// <summary>
        /// 按钮类型
        /// </summary>
        public int? ButtonType { get; set; }

        /// <summary>
        /// js操作函数
        /// </summary>
        public string JsOperatingFunction { get; set; }

        /// <summary>
        /// 按钮图标
        /// </summary>
        public string ButtonIcon { get; set; }

    }
}