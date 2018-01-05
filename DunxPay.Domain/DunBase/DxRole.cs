/**********************************************
文件名：DxRole.cs
作者：dunxingpay.com
日期：2017/11/30
描述：数据表[角色信息表]实体类
**********************************************/
using ServiceStack.DataAnnotations;
using System;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 数据表[角色信息表]实体类
    /// </summary>
    [Alias("DxRole")]
	public class DxRole
	{	       
        /// <summary>
        /// Id
        /// </summary>
        [AutoIncrement,PrimaryKey]
    	public int Id { get; set; }
        /// <summary>
        /// 角色惟一识别码[由系统自动生成,不能重复]
        /// </summary>
    	public string IdentifyCode { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
    	public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
    	public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
    	public int? CreatedByUserId { get; set; }
        /// <summary>
        /// 创建者名称
        /// </summary>
    	public string CreatedBy { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
    	public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 最近修改者姓名
        /// </summary>
    	public string ModifiedBy { get; set; }
        /// <summary>
        /// 是否为系统内置[0:否,1:是],默认值:0,如果是系统内置,则不允许删除
        /// </summary>
    	public bool? IsBuiltin { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
    	public string Description { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
    	public int? ClientId { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
    	public string ClientName { get; set; }
        /// <summary>
        /// 是否可用[0:否,1:是],默认值:1
        /// </summary>
    	public bool? IsEnabled { get; set; }
        /// <summary>
        /// 是否已被删除[0:否,1:是],默认值:0
        /// </summary>
    	public bool? IsDeleted { get; set; }
	}
}