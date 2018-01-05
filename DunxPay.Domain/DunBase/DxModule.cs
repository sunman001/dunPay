/**********************************************
文件名：DxModule.cs
作者：dunxingpay.com
日期：2017/11/30
描述：数据表[模块信息表]实体类
**********************************************/
using ServiceStack.DataAnnotations;
using System;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 数据表[模块信息表]实体类
    /// </summary>
    [Alias("DxModule")]
	public class DxModule
	{	       
        /// <summary>
        /// 自增ID
        /// </summary>
        [AutoIncrement,PrimaryKey]
    	public int Id { get; set; }
        /// <summary>
        /// 模块惟一标识码[由系统自动生成,不能重复]
        /// </summary>
    	public string IdentifyCode { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
    	public string Name { get; set; }
        /// <summary>
        /// 模块编码[平台内的编码不能重复]
        /// </summary>
    	public string Code { get; set; }
        /// <summary>
        /// 父节点识别码
        /// </summary>
    	public string ParentIdentifyCode { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
    	public string RequestUrl { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
    	public string Icon { get; set; }
        /// <summary>
        /// 排序[从小到大]
        /// </summary>
    	public int? Sort { get; set; }
        /// <summary>
        /// 子节点数
        /// </summary>
    	public int? ChildCount { get; set; }
        /// <summary>
        /// 菜单级数
        /// </summary>
    	public int? ChildLevel { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
    	public string Description { get; set; }
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
    	public string CreatedByUserName { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
    	public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// ModifiedByUserName
        /// </summary>
    	public string ModifiedByUserName { get; set; }
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