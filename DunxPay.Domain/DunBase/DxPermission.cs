/**********************************************
文件名：DxPermission.cs
作者：dunxingpay.com
日期：2017/11/30
描述：数据表[模块-角色关系映射表]实体类
**********************************************/
using ServiceStack.DataAnnotations;
using System;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 数据表[模块-角色关系映射表]实体类
    /// </summary>
    [Alias("DxPermission")]
	public class DxPermission
	{	       
        /// <summary>
        /// 自增ID
        /// </summary>
        [AutoIncrement,PrimaryKey]
    	public int Id { get; set; }
        /// <summary>
        /// 权限惟一识别码[由系统自动生成,不能重复]
        /// </summary>
    	public string IdentifyCode { get; set; }
        /// <summary>
        /// 模块惟一标识码[关联DxModule表]
        /// </summary>
    	public string ModuleIdentifyCode { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
    	public string RoleIdentifyCode { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
    	public bool? IsEnabled { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
    	public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
    	public int? CreatedByUserId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
    	public string CreatedBy { get; set; }
	}
}