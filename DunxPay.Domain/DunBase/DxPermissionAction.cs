/**********************************************
文件名：DxPermissionAction.cs
作者：dunxingpay.com
日期：2017/11/30
描述：数据表[权限-操作关系映射表]实体类
**********************************************/
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 数据表[权限-操作关系映射表]实体类
    /// </summary>
    [Alias("DxPermissionAction")]
	public class DxPermissionAction
	{	       
        /// <summary>
        /// Id
        /// </summary>
        [AutoIncrement,PrimaryKey]
    	public int Id { get; set; }
        /// <summary>
        /// 权限识别码,关联[DxPermission]表
        /// </summary>
    	public string PermissionIdentifyCode { get; set; }
        /// <summary>
        /// 操作码
        /// </summary>
    	public string Code { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
    	public bool? IsEnabled { get; set; }
	}
}