/**********************************************
文件名：DxUserRoleMapping.cs
作者：dunxingpay.com
日期：2017/11/30
描述：数据表[用户-角色关系映射表]实体类
**********************************************/
using ServiceStack.DataAnnotations;
using System;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 数据表[用户-角色关系映射表]实体类
    /// </summary>
    [Alias("DxUserRoleMapping")]
	public class DxUserRoleMapping
	{	       
        /// <summary>
        /// 自增ID
        /// </summary>
        [AutoIncrement,PrimaryKey]
    	public int Id { get; set; }
        /// <summary>
        /// 角色识别码,关联[DxRole]表
        /// </summary>
    	public string RoleIdentifyCode { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
    	public int? UserId { get; set; }
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
	}
}